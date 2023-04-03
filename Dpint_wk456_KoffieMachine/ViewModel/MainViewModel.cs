using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KoffieMachineDomain;
using KoffieMachineDomain.DrinkFactory;
using KoffieMachineDomain.Tea;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Input;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class MainViewModel : ViewModelBase, IObserver<User>
    {

        public ObservableCollection<string> LogText { get; private set; }
        private DrinkFactory drinkFactory;

        public ObservableCollection<string> SpecialDrinks { get; set; }
        public PayMethodFactory PayFactory { get; set; }
        public PaymentViewModel PaymentVM { get; set; }
        public UserFactory userFactory { get; set; }

        public ICommand Determine { get; set; }
        public int SpecialId { get; set; }
        public Dictionary<string, int> Specials;
        public TeaBlendRepository TBR { get; set; }
        public List<string> AllTeas { get; set; }
        public string SelectedTea { get; set; }

        private User _user { get; set; }


        public MainViewModel()
        {
            Init();
        }

        private void Init()
        {
            PayFactory = new PayMethodFactory();
            PaymentVM = new PaymentViewModel(PayFactory);

            TBR = new TeaBlendRepository();
            AllTeas = TBR.GetTeaBlend();

            Determine = new RelayCommand(DetermineSpecialId);


            _coffeeStrength = Strength.Normal;
            _sugarAmount = Amount.Normal;
            _milkAmount = Amount.Normal;

            drinkFactory = new DrinkFactory();

            SpecialDrinks = new ObservableCollection<string>(drinkFactory.specialCoffeeNames);

            LogText = new ObservableCollection<string>();
            LogText.Add("Starting up...");
            LogText.Add("Done, what would you like to drink?");

            userFactory = new UserFactory();
            foreach (var item in userFactory.Users)
            {
                userFactory.GetUser(item).Subscribe(this);
            }
            PaymentCardUsernames = new ObservableCollection<string>(userFactory.Users);
            _user = userFactory.FirstUser();

            Specials = new Dictionary<string, int>();
            FillDictionary();
        }

        public void FillDictionary()
        {
            for(int i = 0; i < SpecialDrinks.Count; i++)
            {
                Specials.Add(SpecialDrinks[i], i);
            }
        }



        #region Drink properties to bind to
        private IDrink _selectedDrink;
        public string SelectedDrinkName
        {
            get { return _selectedDrink?.GetName(); }
        }

        public double? SelectedDrinkPrice
        {
            get { return _selectedDrink?.GetPrice(); }
        }
        #endregion Drink properties to bind to

        #region Payment

        public ICommand PayCommand => new RelayCommand<double>(coinValue =>
        {
            if (_selectedDrink == null)
                LogText.Add("Please select a drink first.");
            else
                PaymentVM.PayForDrink(coinValue, LogText, _user, _selectedDrink);

            if(RemainingPriceToPay == 0)
                _selectedDrink = null;
        });

        public double PaymentCardRemainingAmount
        {
            get { return _user.MoneyOnCard; }
        }

        public void OnNext(User value)
        {
            RaisePropertyChanged(() => SelectedPaymentCardUsername);
            RaisePropertyChanged(() => PaymentCardRemainingAmount);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<string> PaymentCardUsernames { get; set; }
        private string _selectedPaymentCardUsername;
        public string SelectedPaymentCardUsername
        {
            get { return _user.Name; }
            set
            {
                _user = userFactory.GetUser(value);
                OnNext(_user);
            }
        }
        public double RemainingPriceToPay
        {
            get { return PaymentVM.remainingPriceToPay; }
            set { PaymentVM.remainingPriceToPay = value; RaisePropertyChanged(() => RemainingPriceToPay); }
        }
        #endregion Payment

        #region Coffee buttons
        private Strength _coffeeStrength;
        public Strength CoffeeStrength
        {
            get { return _coffeeStrength; }
            set { _coffeeStrength = value; RaisePropertyChanged(() => CoffeeStrength); }
        }

        private Amount _sugarAmount;
        public Amount SugarAmount
        {
            get { return _sugarAmount; }
            set { _sugarAmount = value; RaisePropertyChanged(() => SugarAmount); }
        }

        private Amount _milkAmount;
        public Amount MilkAmount
        {
            get { return _milkAmount; }
            set { _milkAmount = value; RaisePropertyChanged(() => MilkAmount); }
        }

        public ICommand DrinkCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = drinkFactory.createDrink(false, false, SugarAmount, MilkAmount, CoffeeStrength, drinkName, false, 0, SelectedTea);
            if (_selectedDrink != null)
            {
                RemainingPriceToPay = _selectedDrink.GetPrice();
                LogText.Add($"Selected {_selectedDrink.GetName()}, price: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}");
                RaisePropertyChanged(() => RemainingPriceToPay);
                RaisePropertyChanged(() => SelectedDrinkName);
                RaisePropertyChanged(() => SelectedDrinkPrice);
            }
        });

        private void DetermineSpecialId()
        {
            for (int i = 0; i < SpecialDrinks.Count; i++)
            {
                if (SpecialDrinks[i] == _selectedDrink.GetName())
                    SpecialId = i;
            }
        }

        public ICommand SpecialDrinkCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = drinkFactory.createDrink(false, false, SugarAmount, MilkAmount, CoffeeStrength, drinkName, true, Specials[drinkName]);
            if (_selectedDrink != null)
            {
                RemainingPriceToPay = _selectedDrink.GetPrice();
                LogText.Add($"Selected {_selectedDrink.GetName()}, price: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}");
                RaisePropertyChanged(() => RemainingPriceToPay);
                RaisePropertyChanged(() => SelectedDrinkName);
                RaisePropertyChanged(() => SelectedDrinkPrice);
            }
        });

        public ICommand DrinkWithSugarCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = drinkFactory.createDrink(false, false, SugarAmount, MilkAmount, CoffeeStrength, drinkName, false, 0, SelectedTea);
            RemainingPriceToPay = 0;

            if (_selectedDrink != null)
            {
                RemainingPriceToPay = _selectedDrink.GetPrice();
                LogText.Add($"Selected {_selectedDrink.GetName()} with sugar, price: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}");
                RaisePropertyChanged(() => RemainingPriceToPay);
                RaisePropertyChanged(() => SelectedDrinkName);
                RaisePropertyChanged(() => SelectedDrinkPrice);
            }
        });

        public ICommand DrinkWithMilkCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = drinkFactory.createDrink(false, true, SugarAmount, MilkAmount, CoffeeStrength, drinkName);

            if (_selectedDrink != null)
            {
                RemainingPriceToPay = _selectedDrink.GetPrice();
                LogText.Add($"Selected {_selectedDrink.GetName()} with milk, price: {RemainingPriceToPay}");
                RaisePropertyChanged(() => RemainingPriceToPay);
                RaisePropertyChanged(() => SelectedDrinkName);
                RaisePropertyChanged(() => SelectedDrinkPrice);
            }
        });

        public ICommand DrinkWithSugarAndMilkCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = drinkFactory.createDrink(true, true, SugarAmount, MilkAmount, CoffeeStrength, drinkName);
            RemainingPriceToPay = 0;

            if (_selectedDrink != null)
            {
                RemainingPriceToPay = _selectedDrink.GetPrice();
                LogText.Add($"Selected {_selectedDrink.GetName()} with sugar and milk, price: {RemainingPriceToPay}");
                RaisePropertyChanged(() => RemainingPriceToPay);
                RaisePropertyChanged(() => SelectedDrinkName);
                RaisePropertyChanged(() => SelectedDrinkPrice);
            }
        });

        #endregion Coffee buttons
    }
}