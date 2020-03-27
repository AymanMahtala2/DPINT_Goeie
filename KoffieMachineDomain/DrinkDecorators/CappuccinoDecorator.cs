using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkDecorators
{
    public class CappuccinoDecorator : DrinkDecorator
    {
        public CappuccinoDecorator(IDrink drink) : base(drink)
        {
            this.Price = 0.8;
        }
        public override string GetName()
        {
            return "Cappuccino";
        }
        public override double GetPrice()
        {
            return this.Price + drink.GetPrice();
        }
        public override void LogDescription(ICollection<string> log)
        {
            drink.LogDescription(log);
            log.Add("Creaming milk...");
            log.Add("Adding milk to coffee...");
            log.Add($"Finished making {GetName()}");
        }
    }
}
