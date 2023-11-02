using System;
using System.Collections.Generic;

namespace task02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyList<int> list = new();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            for (int i = 0; i < list.Length; ++i)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}