using KoffieMachineDomain.DrinkDecorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Tea
{
    public class TeaAdapter : DrinkDecorator
    {
        private Tea Tea { get; set; }
        public double Price { get; set; }

        public TeaAdapter(Tea tea, IDrink drink) : base(drink)
        {
            this.Tea = tea;
            Price = 1.20;
        }

        public override string GetName()
        {
            return "Tea";
        }
        public override double GetPrice()
        {
            return this.Price + drink.GetPrice();
        }
        public override void LogDescription(ICollection<string> log)
        {
            drink.LogDescription(log);
            log.Add($"Adding {Tea.TeaBlend.GetName()}");
            log.Add($"Finished making {GetName()}");
        }
    }
}
