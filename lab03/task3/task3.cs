using System;

namespace task3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter currency RUB to USD: ");
            ExchangeRate.RUBtoUSD = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter currency RUB to EUR: ");
            ExchangeRate.RUBtoEUR = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter currency USD to EUR: ");
            ExchangeRate.USDtoEUR = Convert.ToDouble(Console.ReadLine());

            CurrencyEUR currencyEUR = new(100);
            CurrencyUSD curUSD = currencyEUR;
            Console.WriteLine(curUSD.Value);
        }
    }
}