using System;
namespace task2
{
	public class Car : IEquatable<Car>
	{
		public string Name { get; set; }
		public string Engine { get; set; }
		public double Speed { get; set; }

		public Car(string name, string engine, double speed)
		{
			Name = name;
			Engine = engine;
			Speed = speed;
		}

        public override string ToString()
        {
			return Name;
        }

		public bool Equals(Car? car)
		{
			return Name == car?.Name && Engine == car?.Engine &&
				Speed == car?.Speed;
		}
    }

	public class CarsCatalog
	{
		private Car[] cars;

		public CarsCatalog(params Car[] cars)
		{
			this.cars = new Car[cars.Length];
			cars.CopyTo(this.cars, 0);
		}

		public string this[int i]
		{
			get { return $"{cars[i].Name} with {cars[i].Engine} engine"; }
		}
	}
}

