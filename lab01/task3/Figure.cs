using System;
using System.Collections.Generic;
using PointNS;

namespace FigureNS
{
	public class Figure
	{
		public Figure()
		{
		}

		public Figure(params Point[] parameters)
		{
			switch (parameters.Length)
			{
				case 3:
					name = "Triangle";
					break;
				case 4:
					name = "Rectangle";
					break;
				case 5:
					name = "Pentagon";
					break;
				default:
					throw new DataMisalignedException("Give 3, 4 or 5 points");
                    break;
			}
			points = new Point[parameters.Length];
			parameters.CopyTo(points, 0);
		}

		private double LengthSide(Point A, Point B)
		{
			double lengthX = B.X - A.X;
			double lengthY = B.Y - A.Y;
			return Math.Sqrt(Math.Pow(lengthX, 2) + Math.Pow(lengthY, 2));
		}

		public void PerimeterCalculator()
		{
			perimeter = 0;
			for (int i = 1; i < points.Length; ++i)
			{
				perimeter += LengthSide(points[i], points[i - 1]);
			}
			perimeter += LengthSide(points[0], points[points.Length - 1]);
			Console.WriteLine($"{name} perimeter is: {perimeter}");
		}

		public double Perimeter
		{
			get
			{
				return perimeter;
			}
		}

		public string name { get; }
		private double perimeter;
		private Point[] points;
	}
}

