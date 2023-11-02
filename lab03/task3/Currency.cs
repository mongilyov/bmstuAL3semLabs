using System;
namespace task3
{

	public static class ExchangeRate
	{
        public static double RUBtoUSD { get; set; }
        public static double RUBtoEUR { get; set; }
        public static double USDtoEUR { get; set; }
    }

	public class Currency
	{
		public double Value;

        public Currency(double Value)
        {
            this.Value = Value;
        }
	}

	public class CurrencyUSD : Currency
	{
		

		public CurrencyUSD(double Value) : base(Value)
		{

		}

		public static implicit operator CurrencyEUR(CurrencyUSD curr)
		{
			return new CurrencyEUR(curr.Value / ExchangeRate.USDtoEUR);
		}

        public static implicit operator CurrencyRUB(CurrencyUSD curr)
        {
            return new CurrencyRUB(curr.Value * ExchangeRate.RUBtoUSD);
        }
	}

    public class CurrencyEUR : Currency
    {
        public CurrencyEUR(double Value) : base(Value)
        {

        }

        public static implicit operator CurrencyUSD(CurrencyEUR curr)
        {
            return new CurrencyUSD(curr.Value * ExchangeRate.USDtoEUR);
        }

        public static implicit operator CurrencyRUB(CurrencyEUR curr)
        {
            return new CurrencyRUB(curr.Value * ExchangeRate.RUBtoEUR);
        }
    }

    public class CurrencyRUB : Currency
    {
        public CurrencyRUB(double Value) : base(Value)
        {

        }

        public static implicit operator CurrencyUSD(CurrencyRUB curr)
        {
            return new CurrencyUSD(curr.Value / ExchangeRate.RUBtoUSD);
        }

        public static implicit operator CurrencyEUR(CurrencyRUB curr)
        {
            return new CurrencyEUR(curr.Value / ExchangeRate.RUBtoEUR);
        }
    }
}

