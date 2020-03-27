using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public interface IDrink
    {
        double Price { get; set; }
        string GetName();
        void LogDescription(ICollection<string> log);
        double GetPrice();

    }
}
