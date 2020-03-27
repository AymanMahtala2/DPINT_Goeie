using KoffieMachineDomain.DrinkDecorators;
using KoffieMachineDomain.SpecialCoffees;
using KoffieMachineDomain.Tea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkFactory
{
    public class DrinkFactory
    {
        public const string COFFEE = "Coffee";
        public const string CAFEAULAIT = "Café au Lait";
        public const string CAPPUCCINO = "Cappuccino";
        public const string ESPRESSO = "Espresso";
        public const string WIENERMELAGNE = "Wiener Melange";
        public const string CHOCOLATEDELUXE = "Chocolate Deluxe";
        public const string HOTCHOCOLATE = "Hot Chocolate";
        public const string TEA = "Tea";

        private SpecialCoffeeAdapter _specialCoffeeAdapter;
        private TeaBlendRepository TBR;
        private XMLParser xmlParser;
        public List<string> specialCoffeeNames;
        public List<IDrink> SpecialDrinks { get; set; }

        public DrinkFactory()
        {
            _specialCoffeeAdapter = new SpecialCoffeeAdapter();
            TBR = new TeaBlendRepository();
            specialCoffeeNames = new List<string>();
            SpecialDrinks = new List<IDrink>();
            xmlParser = new XMLParser();
            specialCoffeeNames = xmlParser.GetNames();
        }

        private IDrink ParseSpecialCoffee(int Id, IDrink drink)
        {
            drink = _specialCoffeeAdapter.CreateSpecialCoffee(Id, drink);
            SpecialDrinks.Add(drink);
            return drink;
        }

        public IDrink createDrink(bool sugar, bool milk, Amount sugarStrength, Amount milkStrength, Strength strength, string drinkOption = null, bool special = false, int specialId = 0, string teaKind = null)
        {
            IDrink drink = new Drink();

            if (special)
            {
                drink = ParseSpecialCoffee(specialId, drink);
                SpecialDrinks.Add(drink);
                return drink;
            }


            drink = new StrengthDecorator(drink, strength);

            if (sugar)
                drink = new SugarDecorator(drink, sugarStrength);

            if (milk)
                drink = new MilkDecorator(drink, milkStrength);


            switch (drinkOption)
            {
                case COFFEE:
                    drink = new CoffeeDecorator(drink);
                    break;
                case CAFEAULAIT:
                    drink = new CafeAuLaitDecorator(drink);
                    break;
                case CAPPUCCINO:
                    drink = new CappuccinoDecorator(drink);
                    break;
                case ESPRESSO:
                    drink = new EspressoDecorator(drink);
                    break;
                case WIENERMELAGNE:
                    drink = new WienerMelangeDecorator(drink);
                    break;
                case CHOCOLATEDELUXE:
                    drink = new ChocolateDeluxeDecorator(drink);
                    break;
                case HOTCHOCOLATE:
                    drink = new HotChocolateDecorator(drink);
                    break;
                case TEA:
                    Tea.Tea tea = new Tea.Tea(drink);
                    tea.TeaBlend = TBR.GetKind(teaKind);
                    drink = new TeaAdapter(tea, drink); //nog fixen
                    break;
            }

            return drink;
        }
    }
}
