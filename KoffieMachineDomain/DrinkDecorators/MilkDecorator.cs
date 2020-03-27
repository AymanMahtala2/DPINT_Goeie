using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkDecorators
{
    public class MilkDecorator : DrinkDecorator
    {
        Amount milkStrength;
        public MilkDecorator(IDrink drink, Amount milkStrength) : base(drink)
        {
            this.Price = 0.4;
            this.milkStrength = milkStrength;
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
            log.Add($"Setting milk amount to {milkStrength}.");
            log.Add("Adding milk...");
        }
    }
}
