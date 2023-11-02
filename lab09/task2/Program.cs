using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Linq;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

namespace task2
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

            Dictionary<string, Tuple<double, double>> cityLocation = new();

            using (FileStream fs = new FileStream("city.txt", FileMode.Open))
            {
                using (StreamReader reader = new(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        string s = reader.ReadLine();
                        string pattern = @"\s+[,]?";
                        string[] list = System.Text.RegularExpressions.Regex.Split(s, pattern);
                        if (list.Count() == 4)
                        {
                            list[2] = list[2].TrimEnd(',');
                            cityLocation[list[0] + list[1]] = new(Convert.ToDouble(list[2]), Convert.ToDouble(list[3]));
                        } else if (list.Count() == 3)
                        {
                            list[1] = list[1].TrimEnd(',');
                            cityLocation[list[0]] = new(Convert.ToDouble(list[1]), Convert.ToDouble(list[2]));
                        }
                        
                    }
                }
            }

            while (true)
            {
                Console.Write("Напишите имя города: ");
                string? s = Console.ReadLine();

                var loc = cityLocation[s];

                if (s == null || loc == null)
                {
                    Console.WriteLine("Имя города написано неверно");
                    continue;
                }

                var Weather = GetWeather(loc.Item1, loc.Item2).Result;
                Weather.Show();
            }
        }
    }
}