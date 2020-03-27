using KoffieMachineDomain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class CoinViewModel : IPayment
    {
        public double PayDrink(double insertedMoney, double toPay, ICollection<string> logText, User user, IDrink selectedDrink)
        {
            toPay = Math.Max(Math.Round(toPay - insertedMoney, 2), 0);
            logText.Add($"Inserted {insertedMoney.ToString("C", CultureInfo.CurrentCulture)}, Remaining: {toPay.ToString("C", CultureInfo.CurrentCulture)}.");

            if (selectedDrink != null && toPay == 0)
            {
                selectedDrink.LogDescription(logText);
                logText.Add("------------------");
                selectedDrink = null;

            }
            return toPay;
        }
    }
}
