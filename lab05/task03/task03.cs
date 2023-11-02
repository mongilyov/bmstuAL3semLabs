using System;

namespace task03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyDictionary<string, int> myDictionary = new();
            myDictionary.Add("one", 1);
            myDictionary.Add("two", 2);
            myDictionary.Add("three", 3);
            myDictionary.Add("four", 4);
            myDictionary.Add("five", 5);
            myDictionary.Add("six", 6);
            myDictionary.Add("seven", 7);
            foreach (KeyValuePair<string, int> pair in myDictionary)
            {
                Console.WriteLine($"{pair.Key} to {pair.Value}");
            }
            Console.WriteLine(myDictionary["three"]);
        }
    }
}