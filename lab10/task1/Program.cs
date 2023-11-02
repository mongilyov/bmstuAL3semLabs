using System.Net;
using Microsoft.EntityFrameworkCore;

namespace task1
{
    public class Tickers
    {
        public int Id { get; set; }
        public string TickerSymbol { get; set; }
    }

    public class Prices
    {
        public int Id { get; set; }
        public int TickerId { get; set; }
        public double Price { get; set; }
        public DateTimeOffset Date { get; set; }
    }

    public class TodaysCondition
    {
        public int Id { get; set; }
        public int TickerId { get; set; }
        public bool State { get; set; }
    }

    public class StockContext : DbContext
    {
        public DbSet<Tickers> Tickers { get; set; }
        public DbSet<Prices> Prices { get; set; }
        public DbSet<TodaysCondition> TodaysCondition { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=StockApp;User Id=sa;Password=MyStr0ngPassword!;");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            string[] tickers = File.ReadAllLines("ticker.txt");

            using (var context = new StockContext())
            {
                FillDb(context, tickers);
                UpdateTodaysCondition(context);

                Console.WriteLine("Enter a ticker symbol:");
                var tickerSymbol = Console.ReadLine();

                var ticker = context.Tickers.FirstOrDefault(t => t.TickerSymbol == tickerSymbol);
                if (ticker == null)
                {
                    Console.WriteLine("Ticker symbol not found.");
                    return;
                }

                var todayCondition = context.TodaysCondition.FirstOrDefault(c => c.TickerId == ticker.Id);
                if (todayCondition == null)
                {
                    Console.WriteLine("No data available for today.");
                    return;
                }

                string priceChange;
                if (todayCondition.State)
                {
                    priceChange = "increased";
                }
                else
                {
                    priceChange = "decreased";
                }

                Console.WriteLine($"Price for {tickerSymbol} has {priceChange} today.");

            }
        }
        
        public static void UpdateTodaysCondition(StockContext context)
        {
            var tickerPrices = context.Prices.Include(p => p.TickerId)
                                                   .OrderByDescending(p => p.Date)
                                                   .ToList();
            foreach (var tickerPrice in tickerPrices)
            {
                var previousPrice = tickerPrices.FirstOrDefault(p => p.Date < tickerPrice.Date && p.TickerId == tickerPrice.TickerId);
                if (previousPrice != null)
                {
                    bool state = tickerPrice.Price > previousPrice.Price;

                    var todaysCondition = new TodaysCondition
                    {
                        TickerId = tickerPrice.TickerId,
                        State = state
                    };

                    context.TodaysCondition.Add(todaysCondition);
                }
            }

            context.SaveChanges();
        }

        private static void FillDb(StockContext context, string[] tickers)
        {
            for (int i = 0; i < tickers.Length; ++i)
            {
                var ticker = new Tickers
                {
                    Id = i,
                    TickerSymbol = tickers[i]
                };
                context.Tickers.Add(ticker);

                var arr = GetStockData(tickers[i]);

                foreach (var price in arr)
                {
                    var temp = new Prices
                    {
                        Id = i,
                        TickerId = i,
                        Price = price,
                        Date = DateTimeOffset.UtcNow.AddDays(i - 1)
                    };
                    context.Prices.Add(temp);
                }
            }
        }

        static double[] GetStockData(string ticker)
        {
            long startTimestamp = DateTimeOffset.UtcNow.AddDays(-1).ToUnixTimeSeconds();
            long endTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            string url = $"https://query1.finance.yahoo.com/v7/finance/download/{ticker}?period1={startTimestamp}&period2={endTimestamp}&interval=1d&events=history&includeAdjustedClose=true";

            using (WebClient client = new WebClient())
            {
                try
                {
                    // Скачиваем данные
                    string data = client.DownloadString(url);

                    // Пропускаем заголовок
                    string[] lines = data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    double[] prices = new double[lines.Length - 1];
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] columns = lines[i].Split(',');
                        prices[i - 1] = double.Parse(columns[5]);
                    }

                    return prices;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Произошла ошибка при получении данных для акции {ticker}: {e.Message}");
                    return null;
                }
            }
        }
    }
}