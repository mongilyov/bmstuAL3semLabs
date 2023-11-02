using System.Reflection;
using System.Xml.Linq; 

namespace task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Lion lion = new();
            lion.Country = "Ethiopia";
            lion.HideFromOtherAnimals = false;
            lion.WhatAnimal = Animal.eClassificationAnimal.Camivores;
            lion.Name = "lion";
            Pig pig = new();
            pig.Country = "Everywhere";
            pig.HideFromOtherAnimals = false;
            pig.WhatAnimal = Animal.eClassificationAnimal.Herbivores;
            pig.Name = "pig";
            Cow cow = new();
            cow.Country = "Everywhere";
            cow.HideFromOtherAnimals = false;
            cow.WhatAnimal = Animal.eClassificationAnimal.Herbivores;
            cow.Name = "cow";

            List<Animal> animals = new(3);
            animals.Add(lion);
            animals.Add(pig);
            animals.Add(cow);

            XDocument doc = new(new XElement("animals"));

            foreach (var animal in animals)
            {
                XElement element = new(new XElement("animal",
                    new XElement("type", animal.GetType().ToString()),
                    new XElement("hideFromOtherAnimals", animal.HideFromOtherAnimals.ToString()),
                    new XElement("country", animal.Country),
                    new XElement("comment", ((Comment)animal.GetType().GetCustomAttribute(typeof(Comment))).Commentary)));
                doc.Root.Add(element);
            }

            doc.Save("animals.xml");
            Console.WriteLine(doc);
        }
    }
}