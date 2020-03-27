using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkDecorators
{
    public class StrengthDecorator : DrinkDecorator
    {
        private Strength strength;
        public StrengthDecorator(IDrink drink, Strength strength) : base(drink)
        {
            this.Price = 0.8;
            this.strength = strength;
        }
        public override string GetName()
        {
            return base.GetName();
        }
        public override double GetPrice()
        {
            return drink.GetPrice();
        }
        public override void LogDescription(ICollection<string> log)
        {
            drink.LogDescription(log);
            log.Add($"Setting {base.GetName()} strength to {strength}.");
            log.Add("Adjusting strength...");
        }
    }
}
