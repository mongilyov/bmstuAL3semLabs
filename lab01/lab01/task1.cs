namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"Size of {typeof(bool)} \tis \t{sizeof(bool)} bytes, \tmin:{bool.FalseString} max:{bool.TrueString} ");

            Console.WriteLine($"Size of {typeof(byte)} \tis \t{sizeof(byte)} bytes, \tmin:{byte.MinValue} max:{byte.MaxValue} ");
            Console.WriteLine($"Size of {typeof(sbyte)} \tis \t{sizeof(sbyte)} bytes, \tmin:{sbyte.MinValue} max:{sbyte.MaxValue}");

            Console.WriteLine($"Size of {typeof(char)} \tis \t{sizeof(char)} bytes, \tmin:{char.MinValue} max:{char.MaxValue}");

            Console.WriteLine($"Size of {typeof(short)} \tis \t{sizeof(short)} bytes, \tmin:{short.MinValue} max:{short.MaxValue}");
            Console.WriteLine($"Size of {typeof(ushort)} \tis \t{sizeof(ushort)} bytes, \tmin:{ushort.MinValue} max:{ushort.MaxValue}");

            Console.WriteLine($"Size of {typeof(int)} \tis \t{sizeof(int)} bytes, \tmin:{int.MinValue} max:{int.MaxValue}");
            Console.WriteLine($"Size of {typeof(uint)} \tis \t{sizeof(uint)} bytes, \tmin:{uint.MinValue} max:{uint.MaxValue}");

            Console.WriteLine($"Size of {typeof(long)} \tis \t{sizeof(long)} bytes, \tmin:{long.MinValue} max:{long.MaxValue}");
            Console.WriteLine($"Size of {typeof(ulong)} \tis \t{sizeof(ulong)} bytes, \tmin:{ulong.MinValue} max:{ulong.MaxValue}");

            Console.WriteLine($"Size of {typeof(float)} \tis \t{sizeof(float)} bytes, \tmin:{float.MinValue} max:{float.MaxValue}");
            Console.WriteLine($"Size of {typeof(double)} \tis \t{sizeof(double)} bytes, \tmin:{double.MinValue} max:{double.MaxValue}");
            Console.WriteLine($"Size of {typeof(decimal)} \tis \t{sizeof(decimal)} bytes, \tmin:{decimal.MinValue} max:{decimal.MaxValue}");
        }
    }
}