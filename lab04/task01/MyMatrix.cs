using System;
namespace task01
{
	public class MyMatrix
	{
		private int m;
		private int n;
		private double[,] array;

		public MyMatrix(int m, int n)
		{
            this.m = m;
            this.n = n;
            array = new double[m, n];
        }

        public MyMatrix(int m, int n, int value) : this(m, n)
        {
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
					array[i, j] = value;
                }
            }
        }

        public MyMatrix(int m, int n, int from, int to) : this(m, n)
		{
			Random random = new();

			for (int i = 0; i < m; ++i)
			{
				for (int j = 0; j < n; ++j)
				{
					array[i, j] = random.Next(from, to);
				}
			}
		}

		public void Print()
		{
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
					Console.Write($"{array[i, j]} ");
                }
				Console.WriteLine();
            }
        }

		public double this[int m, int n]
		{
			get => array[m, n];
			set => array[m, n] = value;
		}

		public static MyMatrix operator +(MyMatrix m1, MyMatrix m2)
		{
			if (m1.m != m2.m || m1.n != m2.n)
			{
				return null;
			}

			MyMatrix m3 = new(m1.m, m1.n);

			for (int i = 0; i < m1.m; ++i)
			{
				for (int j = 0; j < m1.n; ++j)
				{
					m3[i, j] = m1[i, j] + m2[i, j];
				}
			}
			return m3;
		}

        public static MyMatrix operator -(MyMatrix m1, MyMatrix m2)
        {
            if (m1.m != m2.m || m1.n != m2.n)
            {
                return null;
            }

            MyMatrix m3 = new(m1.m, m1.n);

            for (int i = 0; i < m1.m; ++i)
            {
                for (int j = 0; j < m1.n; ++j)
                {
                    m3[i, j] = m1[i, j] - m2[i, j];
                }
            }
            return m3;
        }

		public static MyMatrix operator *(MyMatrix m1, double value)
		{
            MyMatrix newMatrix = m1;

            for (int i = 0; i < m1.m; ++i)
            {
                for (int j = 0; j < m1.n; ++j)
                {
                    newMatrix[i, j] *= value;
                }
            }
            return newMatrix;
        }

        public static MyMatrix operator /(MyMatrix m1, double value)
        {
            MyMatrix newMatrix = m1;

            for (int i = 0; i < m1.m; ++i)
            {
                for (int j = 0; j < m1.n; ++j)
                {
                    newMatrix[i, j] /= value;
                }
            }
            return newMatrix;
        }

        public static MyMatrix operator *(MyMatrix m1, MyMatrix m2)
        {
            if (m1.n != m2.m)
            {
                return null;
            }

            MyMatrix m3 = new(m1.m, m2.n, 0);

            for (int i = 0; i < m3.m; ++i)
            {
                for (int j = 0; j < m3.n; ++j)
                {
                    for (int k = 0; k < m1.n; ++k)
                    {
                        m3[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
            return m3;
        }
    }
}

