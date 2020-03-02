using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqXml34
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "input.xml";
            string ouput = "ouput.xml";
            XDocument d = XDocument.Load(input);

            var firstElements = from e in d.Root.Elements()
                    where e.HasAttributes
                    select e;

            foreach (var e in firstElements)
            {
                foreach (var childNode in e.Elements())
                {
                    XElement xElement =  new XElement("empty"); ;
                    foreach (var atr in e.Attributes())
                    {
                        xElement = new XElement(atr.Name);
                        xElement.Value = atr.Value;
                    }
                    childNode.Add(xElement);  
                }
                Console.WriteLine();
             }
            
            foreach (var e in firstElements)
                e.ReplaceAttributes();
            
            d.Save(ouput);
            Process.Start(input);
            Process.Start(ouput);
            Console.ReadKey();
        }
    }
}
