using System;

namespace task02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Car[] cars =
            {
                new ("Mercedes", "2015", 200 ),
                new ("Lada", "1980", 100),
                new ("Ferrari", "2010", 300)
            };

            Array.Sort(cars, new CarComparer("speed"));

            foreach (Car car in cars)
            {
                car.Print();
            }
            Console.WriteLine();

            Array.Sort(cars, new CarComparer("year"));

            foreach (Car car in cars)
            {
                car.Print();
            }
            Console.WriteLine();

            Array.Sort(cars, new CarComparer("name"));

            foreach (Car car in cars)
            {
                car.Print();
            }
            Console.WriteLine();
        }
    }
}