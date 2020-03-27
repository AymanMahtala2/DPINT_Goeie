using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class UserFactory
    {
        private Dictionary<string, User> _userDictionary;
        public IEnumerable<string> Users
        {
            get { return _userDictionary.Keys; }
        }

        public UserFactory()
        {
            _userDictionary = new Dictionary<string, User>();
            _userDictionary.Add("Arjen", new User(5.0, "Arjen"));
            _userDictionary.Add("Bert", new User(3.5, "Bert"));
            _userDictionary.Add("Chris", new User(7.0, "Chris"));
            _userDictionary.Add("Daan", new User(6.0, "Daan"));
        }


        public User GetUser(String name)
        {
            if (Users.Contains(name))
            {
                return _userDictionary[name];
            }

            return null;
        }

        public User FirstUser()
        {
            return _userDictionary.First().Value;
        }
    }
}
