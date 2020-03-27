using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkDecorators
{
    public class ChocolateDeluxeDecorator : DrinkDecorator
    {
        public ChocolateDeluxeDecorator(IDrink drink) : base(drink)
        {
            this.Price = 1.6;
        }

        public override string GetName()
        {
            return "Chocolate Deluxe";
        }

        public override double GetPrice()
        {
            return this.Price + drink.GetPrice();
        }

        public override void LogDescription(ICollection<string> log)
        {
            drink.LogDescription(log);
            log.Add("Filling with chocolate deluxe...");
            log.Add($"Finished making {GetName()}");
        }
    }
}
