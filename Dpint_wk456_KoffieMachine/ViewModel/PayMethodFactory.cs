using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class PayMethodFactory
    {
        private IDictionary<string, IPayment> _factory;

        public PayMethodFactory()
        {
            _factory = new Dictionary<string, IPayment>();

            _factory.Add("Card", new PayCardViewModel());
            _factory.Add("Coin", new CoinViewModel());
        }

        public IPayment getPayVM(string name)
        {
            try
            {
                return _factory[name];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
