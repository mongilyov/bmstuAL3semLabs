using System;
namespace task2
{
	public class Vehicle
	{
		protected double x;
		protected double y;
		protected double cost;
		protected double speed;
		protected int year;

		public Vehicle(double x, double y, double cost, double speed, int year)
		{
			this.x = x;
			this.y = y;
			this.cost = cost;
			this.speed = speed;
			this.year = year;
		}

		public virtual void Print()
		{
			Console.WriteLine(this.GetType());
			Console.WriteLine($"Coordinates are: x: {x}, y: {y}");
			Console.WriteLine($"Cost is: {cost}");
			Console.WriteLine($"Speed is: {speed}");
			Console.WriteLine($"Production year is: {year}");
		}
	}

	public class Car : Vehicle
	{
		public Car(double x, double y, double cost, double speed, int year) : base(x, y, cost, speed, year)
		{

		}

		public override void Print()
		{
			base.Print();
		}
	}

	public class Plane : Vehicle
	{
		private int maxHeight;
		private int passengers;

		public Plane(double x, double y, double cost, double speed, int year, int maxHeight, int passengers) : base(x, y, cost, speed, year)
        {
			this.maxHeight = maxHeight;
			this.passengers = passengers;
		}

        public override void Print()
        {
            base.Print();
			Console.WriteLine($"Max height is: {maxHeight}");
            Console.WriteLine($"Number of passengers is: {passengers}");
        }
    }

	public class Ship : Vehicle
	{
		private string port;
		private int passengers;

		public Ship(double x, double y, double cost, double speed, int year, string port, int passengers) : base(x, y, cost, speed, year)
        {
			this.port = port;
			this.passengers = passengers;
		}

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Port is: {port}");
            Console.WriteLine($"Number of passengers is: {passengers}");
        }
    }
}

