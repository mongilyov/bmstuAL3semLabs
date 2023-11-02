using System;
using System.Text.Json;

namespace task2
{
    public class OneDayWeatherDataModel : IEquatable<OneDayWeatherDataModel>
    {
        //Name of the City
        public string Name { get; set; }

        public Main Main { get; set; }

        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public Wind Wind { get; set; }

        public Clouds Clouds { get; set; }
        public Sys Sys { get; set; }

        public int Visibility { get; set; }
        public int Dt { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public int Cod { get; set; }

        public void Show()
        {
            Console.WriteLine($"Name: {Name}, Temp: {Main.Temp}, Descr: {Weather[0].Description}, Country: {Sys.Country}"
                );
        }
        public bool Equals(OneDayWeatherDataModel other)
        {
            return this.Sys.Country == other.Sys.Country;
        }

    }

    public class Main
    {
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public double Temp_min { get; set; }
        public double Temp_max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }

    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double Gust { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public double Message { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }


    public struct weather
    {
        public string country { get; set; }
        public string name { get; set; }
        public double temp { get; set; }
        public string description { get; set; }

        public void Show()
        {
            Console.WriteLine($"Country is {country}, name: {name}, temp: {temp}, description: {description}");
        }
    }
}

