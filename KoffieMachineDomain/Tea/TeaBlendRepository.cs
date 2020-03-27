using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace KoffieMachineDomain.Tea
{
    public class TeaBlendRepository
    {
        private IEnumerable<string> BlendNames { get; set; }
        private Dictionary<string, TeaBlend> _blend;

        public TeaBlendRepository()
        {
            BlendNames = new List<string>() {"Oolong", "Honeybush", "Chinese" };
            _blend = new Dictionary<string, TeaBlend>();
            _blend.Add("Oolong", new TeaBlend("Oolong", Color.FromRgb(100, 100, 100)));
            _blend.Add("Honeybush", new TeaBlend("Honeybush", Color.FromRgb(150, 150, 150)));
            _blend.Add("Chinese", new TeaBlend("Chinese", Color.FromRgb(220, 220, 220)));
        }

        public List<string> GetTeaBlend()
        {
            List<string> Blends = BlendNames.ToList<string>();
            return Blends;
        }

        public TeaBlend GetKind(string teaName)
        {
            return _blend[teaName];
        }
    }
}
