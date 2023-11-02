using System;

namespace task03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CarCatalog carCatalog = new(
                new ("Mercedes", "2015", 200 ),
                new ("Lada", "1980", 100),
                new ("Ferrari", "2010", 300),
                new ("Toyota", "2016", 170));

            foreach (Car car in carCatalog)
            {
                car.Print();
            }

            Console.WriteLine();

            foreach(Car car in carCatalog.GetCarsReversed())
            {
                car.Print();
            }

            Console.WriteLine();

            foreach (Car car in carCatalog.GetCarsFromYear("2010"))
            {
                car.Print();
            }

            Console.WriteLine();

            foreach (Car car in carCatalog.GetCarsFromSpeed(200))
            {
                car.Print();
            }
        }
    }
}