using KoffieMachineDomain.DrinkDecorators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.SpecialCoffees
{
    public class SpecialCoffeeDecorator : DrinkDecorator
    {
        private XMLParser coffeeParser;
        private int coffeeID;
        private string name;
        private bool sugar;
        private bool milk;
        private string strongDrink;
        private bool cream;

        public SpecialCoffeeDecorator(IDrink drink) : base(drink)
        {
            this.Price = 3.0;
            coffeeParser = new XMLParser();
        }

        public void ParseCoffee(int Id)
        {
            coffeeID = Id;
            name = coffeeParser.names[Id];
            if (coffeeParser.sugars[Id] == "true")
                sugar = true;
            else
                sugar = false;
            if (coffeeParser.milks[Id] == "true")
                milk = true;
            else
                milk = false;
            strongDrink = coffeeParser.strongDrinks[Id];
            if (coffeeParser.creams[Id] == "true")
                cream = true;
            else
                cream = false;
        }
        public override string GetName()
        {
            return name;
        }
        public override double GetPrice()
        {
            return this.Price + drink.GetPrice();
        }
        public override void LogDescription(ICollection<string> log)
        {
            log.Add($"Setting coffee amount to {Amount.Few}.");
            drink.LogDescription(log);
            if (sugar)
                log.Add("Adding sugar...");
            if (milk)
            {
                log.Add("Creaming milk...");
                log.Add("Adding milk to coffee...");
            }
            log.Add($"Adding {strongDrink}...");
            if(cream)
                log.Add("Adding cream...");
            log.Add($"Finished making {GetName()}");
        }
    }
}
