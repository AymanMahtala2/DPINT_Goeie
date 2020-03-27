using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkDecorators
{
    public class HotChocolateDecorator : DrinkDecorator
    {
        public HotChocolateDecorator(IDrink drink) : base(drink)
        {
            this.Price = 1.3;
        }

        public override string GetName()
        {
            return "Hot Chocolate";
        }

        public override double GetPrice()
        {
            return this.Price + drink.GetPrice();
        }

        public override void LogDescription(ICollection<string> log)
        {
            drink.LogDescription(log);
            log.Add("Filling with hot chocolate...");
            log.Add($"Finished making {GetName()}");
        }
    }
}
