using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace KoffieMachineDomain.SpecialCoffees
{
    public class XMLParser
    {
        public XmlDocument coffees;
        XDocument doc;
        public List<string> names;
        public List<string> sugars;
        public List<string> milks;
        public List<string> strengths;
        public List<string> strongDrinks;
        public List<string> creams;

        public List<string> namesForShow;
        public List<IDrink> SpecialCoffees { get; set; }

        public XMLParser()
        {
            coffees = new XmlDocument();
            coffees.Load("Coffees.xml");
            doc = XDocument.Load("Coffees.xml");
            XmlElement root = coffees.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("coffee");
            names = new List<string>();
            sugars = new List<string>();
            milks = new List<string>();
            strengths = new List<string>();
            strongDrinks = new List<string>();
            creams = new List<string>();
            namesForShow = new List<string>();
            GetAllCoffeesFromXML();
        }

        public List<string> GetNames()
        {
            var namesVar = doc.Descendants("name");
            foreach (var name in namesVar)
            {
                namesForShow.Add(name.Value);
            }
            return namesForShow;
        }

        public void GetAllCoffeesFromXML()
        {
            var namesVar = doc.Descendants("name");
            var sugarVar = doc.Descendants("sugar");
            var milkVar = doc.Descendants("milk");
            var strengthVar = doc.Descendants("strength");
            var strongDrinkVar = doc.Descendants("strongDrink");
            var creamVar = doc.Descendants("cream");

            foreach (var name in namesVar)
            {
                names.Add(name.Value);
            }
            foreach (var sugar in sugarVar)
            {
                sugars.Add(sugar.Value);
            }
            foreach (var milk in milkVar)
            {
                milks.Add(milk.Value);
            }
            foreach (var strength in strengthVar)
            {
                strengths.Add(strength.Value);
            }
            foreach (var strongDrink in strongDrinkVar)
            {
                strongDrinks.Add(strongDrink.Value);
            }
            foreach (var cream in creamVar)
            {
                creams.Add(cream.Value);
            }

        }
    }
}
