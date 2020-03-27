using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace KoffieMachineDomain.Tea
{
    public struct TeaBlend
    {
        Color bagColor;
        string name;

        public TeaBlend(string name, Color bagColor)
        {

            this.bagColor = bagColor;
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
    }
}
