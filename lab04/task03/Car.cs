using System;
using System.Collections;

namespace task03
{
    public class Car
    {
        public string Name { get; set; }
        public string ProductionYear { get; set; }
        public double MaxSpeed { get; set; }
        public Car(string name, string prodYear, double speed)
        {
            Name = name;
            ProductionYear = prodYear;
            MaxSpeed = speed;
        }

        public void Print()
        {
            Console.WriteLine($"{Name}, production year: {ProductionYear}, max speed: {MaxSpeed}");
        }
    }

    public class CarCatalog : IEnumerator, IEnumerable
    {
        private Car[] cars;
        int position = -1;

        public CarCatalog(params Car[] cars)
        {
            this.cars = new Car[cars.Length];
            cars.CopyTo(this.cars, 0);
        }

        public IEnumerable<Car> GetCarsReversed()
        {
            for (int i = cars.Length - 1; i >= 0; --i)
            {
                yield return cars[i];
            }
        }

        public IEnumerable<Car> GetCarsFromYear(string year)
        {
            for (int i = 0; i < cars.Length; ++i)
            {
                if (year.CompareTo(cars[i].ProductionYear) <= 0)
                {
                    yield return cars[i];
                }
            }
        }

        public IEnumerable<Car> GetCarsFromSpeed(double speed)
        {
            for (int i = 0; i < cars.Length; ++i)
            {
                if (cars[i].MaxSpeed >= speed)
                {
                    yield return cars[i];
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            ++position;
            return (position < cars.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get => cars[position];
        }
    }

    public class CarComparer : IComparer<Car>
    {
        private string type;

        public CarComparer(string type)
        {
            this.type = type;
        }

        public int Compare(Car? car1, Car? car2)
        {
            if (type == "speed")
            {
                if (car1?.MaxSpeed < car2?.MaxSpeed)
                {
                    return -1;
                }
                else if (car1?.MaxSpeed > car2?.MaxSpeed)
                {
                    return +1;
                }
                else
                {
                    return 0;
                }
            }
            else if (type == "year")
            {
                return car1.ProductionYear.CompareTo(car2.ProductionYear);
            }
            else if (type == "name")
            {
                return car1.Name.CompareTo(car2.Name);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}

