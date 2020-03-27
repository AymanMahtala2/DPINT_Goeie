using KoffieMachineDomain.DrinkDecorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Tea
{
    public class Tea : DrinkDecorator
    {
        public TeaBlend TeaBlend { get; set; }
        public int AmountOfSugar { get; set; }

        public Tea(IDrink drink) : base(drink)
        {
            this.Price = 0.2;
        }

        public void AddSugar()
        {
            AmountOfSugar += 1;
        }
        public void RemoveSugar()
        {
            if (AmountOfSugar != 0)
                AmountOfSugar -= 1;
        }
    }
}
