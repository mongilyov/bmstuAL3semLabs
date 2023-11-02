namespace task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Car car = new(1, 2, 1000, 200, 1999);
            Plane plane = new(1, 2, 1000, 200, 1999, 30000, 300);
            Ship ship = new(1, 2, 1000, 200, 1999, "North River Port", 50);
            car.Print();
            plane.Print();
            ship.Print();
        }
    }
}
