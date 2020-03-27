using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.SpecialCoffees
{
    public class SpecialCoffeeAdapter
    {
        public SpecialCoffeeAdapter()
        {

        }

        public SpecialCoffeeDecorator CreateSpecialCoffee(int Id, IDrink drink)
        {
            SpecialCoffeeDecorator specialCoffeeDecorator = new SpecialCoffeeDecorator(drink);
            specialCoffeeDecorator.ParseCoffee(Id);
            return specialCoffeeDecorator;

        }
    }
}
