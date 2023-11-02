using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Linq;
using System.Collections;

namespace task1
{
    public class Program
    {
        static HttpClient client = new();

        static async Task<OneDayWeatherDataModel> GetWeather(double lat, double lon)
        {
            HttpResponseMessage a = await client.GetAsync($"data/2.5/weather?lat={lat}&lon={lon}&appid=0a184e806f68bd923ca11cf17061f1f8");
            string data = await a.Content.ReadAsStringAsync();
            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true
            };
            var w = JsonSerializer.Deserialize<OneDayWeatherDataModel>(data, options);
            return w;
        }
        
        public static void Main(string[] args)
        {
            client.BaseAddress = new Uri("https://api.openweathermap.org/");
            List<OneDayWeatherDataModel> list = new(50);
            Random random = new();

            while (list.Count < 50)
            {
                var lat = random.NextDouble() * 180 - 90;
                var lon = random.NextDouble() * 360 - 180;
                var temp = GetWeather(lat, lon).Result;
                if (temp.Name == null || temp.Sys.Country == null)
                {
                    continue;
                }
                list.Add(temp);
            }

            foreach (var w in list)
            {
                w.Show();
            }

            string minCountry = list.Min(a => a.Main.Temp);
            string maxCountry = list.Max(a => a.Main.Temp);
            double averageTemp = list.Average(a => a.Main.Temp);

            var list1 = list;
            int unique = list1.Distinct().Count();
            var first = list.First(a => a.Weather[0].Description == "clear sky" ||
            a.Weather[0].Description == "rain" || a.Weather[0].Description == "few clouds");
            Console.WriteLine($"Min is {minCountry}, max is {maxCountry}");
            Console.WriteLine($"Average is {averageTemp}");
            Console.WriteLine($"Unique countries number: {unique}");
            Console.WriteLine($"{first.Name} in {first.Sys.Country}");
        }
    }
}