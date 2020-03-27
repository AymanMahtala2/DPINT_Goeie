using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkDecorators
{
    public class SugarDecorator : DrinkDecorator
    {
        Amount sugar;
        public SugarDecorator(IDrink drink, Amount sugar) : base(drink)
        {
            this.Price = 0.8;
            this.sugar = sugar;
        }
        public override string GetName()
        {
            return base.GetName();
        }
        public override double GetPrice()
        {
            return Price + drink.GetPrice();
        }
        public override void LogDescription(ICollection<string> log)
        {
            drink.LogDescription(log);
            log.Add($"Setting sugar amount to {sugar}.");
            log.Add("Adding sugar...");
        }
    }
}
