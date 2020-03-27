using KoffieMachineDomain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class PayCardViewModel : IPayment
    {
        public double PayDrink(double insertedMoney, double toPay, ICollection<string> logText, User user, IDrink selectedDrink)
        {
            if (toPay <= user.MoneyOnCard)
            {
                insertedMoney = toPay;

                user.MoneyOnCard -= toPay;
                toPay = 0;
            }
            else // Pay what you can, fill up with coins later.
            {
                insertedMoney = user.MoneyOnCard;

                toPay -= user.MoneyOnCard;
                user.MoneyOnCard = 0;
            }
            logText.Add($"Inserted {insertedMoney.ToString("C", CultureInfo.CurrentCulture)}, Remaining: {toPay.ToString("C", CultureInfo.CurrentCulture)}.");
            if (selectedDrink != null && toPay == 0)
            {
                selectedDrink.LogDescription(logText);
                logText.Add("------------------");
            }
            return toPay;
        }
    }
}
