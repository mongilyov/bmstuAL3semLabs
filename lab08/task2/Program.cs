using System;
using System.Xml.Serialization;

namespace task12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Lion));

            using (FileStream fs = new FileStream("lion.xml", FileMode.OpenOrCreate))
            {
                Lion? lion = xmlSerializer.Deserialize(fs) as Lion;
                lion.Show();
            }
        }
    }
    
}