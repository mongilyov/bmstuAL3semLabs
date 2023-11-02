using System;

namespace task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Car car1 = new("Mercedes", "V8", 200);
            Car car2 = new("Lada", "V4", 80);
            Car car3 = new("Audi", "V6", 150);
            Car car4 = new("Mercedes", "V8", 200);
            Console.WriteLine(car1.Equals(car2));
            Console.WriteLine(car1.Equals(car4));
            CarsCatalog carsCatalog = new(car1, car2, car3);
            Console.WriteLine(carsCatalog[0]);
            Console.WriteLine(carsCatalog[1]);
            Console.WriteLine(carsCatalog[2]);
        }
    }
}