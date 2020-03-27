using KoffieMachineDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public interface IPayment
    {
        double PayDrink(double insertedMoney, double toPay, ICollection<String> logText, User user, IDrink selectedDrink);
    }
}
