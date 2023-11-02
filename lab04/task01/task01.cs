using System;

namespace task01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyMatrix m1 = new(3, 4, 0, 100);
            MyMatrix m2 = new(4, 5, 0, 100);
            m1.Print();
            Console.WriteLine();
            m2.Print();
            Console.WriteLine();
            var m3 = m1 * m2;
            m3.Print();
        }
    }
}