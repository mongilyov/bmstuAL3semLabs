using System;
using FigureNS;
using PointNS;

namespace task3
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Figure figure = new(new Point(1, 1), new Point(1, 2), new Point(2, 2), new Point(2, 1));
			Console.WriteLine(figure.name);
			figure.PerimeterCalculator();
		}
	}
}

