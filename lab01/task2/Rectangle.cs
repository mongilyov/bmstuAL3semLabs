using System;
namespace RectangleNS
{
	public class Rectangle
	{
		public Rectangle()
		{
		}

		public Rectangle(double side1, double side2)
		{
			this.side1 = side1;
			this.side2 = side2;
		}

		private double CalculateArea()
		{
			return side1 * side2;
		}

		private double CalculatePerimeter()
		{
			return (side1 + side2) * 2;
		}

		public double Area
		{
			get
			{
				return CalculateArea();
			}
		}

		public double Perimeter
		{
			get
			{
				return CalculatePerimeter();
			}
		}

		private double side1;
		private double side2;

	}
}

