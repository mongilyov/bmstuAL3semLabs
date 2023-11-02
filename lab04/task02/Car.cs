using System;
namespace task02
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
            } else if (type == "year")
			{
				return car1.ProductionYear.CompareTo(car2.ProductionYear);
            } else if (type == "name")
			{
				return car1.Name.CompareTo(car2.Name);
			} else
			{
				throw new Exception();
			}
		}
	}
}

