using System;
using System.Xml.Serialization;

namespace task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Lion lion = new("everywhere", false, "lion", Animal.eClassificationAnimal.Camivores);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Lion));

            using (FileStream fs = new FileStream("lion.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, lion);

                Console.WriteLine("Object has been serialized");
            }
        }
    }
}