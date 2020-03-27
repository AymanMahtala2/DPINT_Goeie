using GalaSoft.MvvmLight;
using KoffieMachineDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class PaymentViewModel : ViewModelBase
    {
        private PayMethodFactory _payMethodFactory;
        private IPayment _selectedPaymentMethod;
        public double remainingPriceToPay;

        public PaymentViewModel(PayMethodFactory payMethodFactory)
        {
            _payMethodFactory = payMethodFactory;
        }

        public void PayForDrink(double coinValue, ICollection<String> logText, User selecteduser, IDrink selectedDrink)
        {
            if (selectedDrink == null)
            {
                logText.Add("Please select a drink first.");
            }
            else
            {
                SelectMethod(coinValue);
                remainingPriceToPay = _selectedPaymentMethod.PayDrink(coinValue, remainingPriceToPay, logText, selecteduser, selectedDrink);
                RaisePropertyChanged(() => remainingPriceToPay);
            }
        }

        private void SelectMethod(double coinValue)
        {
            if (coinValue == 0)
            {
                _selectedPaymentMethod = _payMethodFactory.getPayVM("Card");
                return;
            }
            _selectedPaymentMethod = _payMethodFactory.getPayVM("Coin");
        }
    }
}
