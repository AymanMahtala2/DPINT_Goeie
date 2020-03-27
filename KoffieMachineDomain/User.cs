using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class User : Observable<User>
    {
        private double _moneyOnCard;
        private string _name;

        public User(double money, string name)
        {
            _moneyOnCard = money;
            _name = name;
        }

        public double MoneyOnCard
        {
            get { return _moneyOnCard; }
            set { _moneyOnCard = value; Notify(this); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; Notify(this); }
        }
    }
}
