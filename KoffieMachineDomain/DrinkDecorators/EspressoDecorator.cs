using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkDecorators
{
    public class EspressoDecorator : DrinkDecorator
    {
        public EspressoDecorator(IDrink drink) : base(drink)
        {
            this.Price = 0.7;
        }
        public override string GetName()
        {
            return "Espresso";
        }
        public override double GetPrice()
        {
            return this.Price + drink.GetPrice();
        }
        public override void LogDescription(ICollection<string> log)
        {
            log.Add($"Setting coffee amount to {Amount.Few}.");
            drink.LogDescription(log);

            log.Add("Creaming milk...");
            log.Add("Adding milk to coffee...");
            log.Add($"Finished making {GetName()}");
        }
    }
}
