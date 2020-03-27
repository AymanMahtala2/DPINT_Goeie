using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkDecorators
{
    public class DrinkDecorator : IDrink
    {
        public double Price { get; set; }
        public IDrink drink;

        public DrinkDecorator(IDrink drink)
        {
            this.drink = drink;
        }

        public virtual string GetName()
        {
            return drink.GetName();
        }

        public virtual double GetPrice()
        {
            return Price;
        }

        public virtual void LogDescription(ICollection<string> log)
        {

        }
    }
}
