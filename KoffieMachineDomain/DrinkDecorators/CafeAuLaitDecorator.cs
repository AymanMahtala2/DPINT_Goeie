using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkDecorators
{
    public class CafeAuLaitDecorator : DrinkDecorator
    {
        public CafeAuLaitDecorator(IDrink drink) : base(drink)
        {
            this.Price = 0.8;
        }

        public override string GetName()
        {
            return "Café au Lait";
        }

        public override double GetPrice()
        {
            return this.Price + drink.GetPrice();
        }

        public override void LogDescription(ICollection<string> log)
        {
            drink.LogDescription(log);
            log.Add("Filling half with coffee...");
            log.Add("Filling other half with milk...");
            log.Add($"Finished making {GetName()}");
        }
    }
}
