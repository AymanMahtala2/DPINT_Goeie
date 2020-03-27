using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkDecorators
{
    public class CoffeeDecorator : DrinkDecorator
    {
        public CoffeeDecorator(IDrink drink) : base(drink)
        {
            this.Price = 0;
        }
        public override void LogDescription(ICollection<string> log)
        {
            drink.LogDescription(log);
            log.Add($"Finished making {GetName()}");
        }
        public override string GetName()
        {
            return "Coffee";
        }
        public override double GetPrice()
        {
            return drink.GetPrice();
        }
    }
}
