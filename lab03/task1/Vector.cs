using System;
namespace task1
{
	public struct Vector
	{
		private double x;
		private double y;
		private double z;

		public Vector(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public static Vector operator +(Vector v1, Vector v2)
		{
			return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
		}

		public static Vector operator *(Vector v, double i)
		{
			return new Vector(v.x * i, v.y * i, v.z * i);
		}

		public static double operator *(Vector v1, Vector v2)
		{
			// scalar
			return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
		}

		public static bool operator <(Vector v1, Vector v2)
		{
			return Math.Sqrt(Math.Pow(v1.x, 2) + Math.Pow(v1.y, 2)
				+ Math.Pow(v1.z, 2)) < Math.Sqrt(Math.Pow(v2.x, 2)
				+ Math.Pow(v2.y, 2) + Math.Pow(v2.z, 2));
        }

        public static bool operator >(Vector v1, Vector v2)
        {
            return Math.Sqrt(Math.Pow(v1.x, 2) + Math.Pow(v1.y, 2)
                + Math.Pow(v1.z, 2)) > Math.Sqrt(Math.Pow(v2.x, 2)
                + Math.Pow(v2.y, 2) + Math.Pow(v2.z, 2));
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            return Math.Sqrt(Math.Pow(v1.x, 2) + Math.Pow(v1.y, 2)
                + Math.Pow(v1.z, 2)) == Math.Sqrt(Math.Pow(v2.x, 2)
                + Math.Pow(v2.y, 2) + Math.Pow(v2.z, 2));
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1==v2);
        }
    }
}

