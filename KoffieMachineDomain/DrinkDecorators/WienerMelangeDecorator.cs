using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkDecorators
{
    public class WienerMelangeDecorator : DrinkDecorator
    {
        public WienerMelangeDecorator(IDrink drink) : base(drink)
        {

        }
        public override string GetName()
        {
            return "Wiener Melange";
        }
        public override double GetPrice()
        {
            return 2 * drink.GetPrice();
        }
        public override void LogDescription(ICollection<string> log)
        {
            drink.LogDescription(log);
            log.Add($"Finished making {GetName()}");
        }
    }
}
