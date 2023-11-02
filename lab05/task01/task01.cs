using System;

namespace task01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyMatrix myMatrix = new(5, 5, 100, 1000);
            myMatrix.Show();
            Console.WriteLine();
            myMatrix.ChangeSize(4, 8
                );
            myMatrix.Show();
        }
    }
}