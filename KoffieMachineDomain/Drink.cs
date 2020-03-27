using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Drink : IDrink
    {
        public double Price { get; set; }

        public Drink()
        {
            Price = 1.00;
        }
        public void LogDescription(ICollection<string> log)
        {

        }
        public string GetName()
        {
            return "";
        }
        public double GetPrice()
        {
            return Price;
        }
    }
}
