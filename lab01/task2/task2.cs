using RectangleNS;

namespace task2
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.Write("Enter first side of the rectangle: ");
			int side1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second side of the rectangle: ");
            int side2 = Convert.ToInt32(Console.ReadLine());
			Rectangle rectangle = new(side1, side2);
			Console.WriteLine($"Rectangle area: {rectangle.Area}");
            Console.WriteLine($"Rectangle perimeter: {rectangle.Perimeter}");
        }
	}
}

