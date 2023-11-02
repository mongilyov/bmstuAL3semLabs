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

        public void Fill(int from, int to)
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

        public void ChangeSize(int rows, int columns)
        {
            if(rows <= m && columns <= n)
            {
                m = rows;
                n = columns;
            }
            double[,] newArray = new double[rows, columns];
            for (int i = 0; i < m; ++i)
            {
                if (i == rows)
                {
                    break;
                }
                for (int j = 0; j < n; ++j)
                {
                    if (j == columns)
                    {
                        continue;
                    }
                    newArray[i, j] = array[i, j];
                }
            }
            
            Random random = new();
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    if (i < m && j < n)
                    {
                        continue;
                    }
                    newArray[i, j] = random.Next();
                }
            }
            m = rows;
            n = columns;
            array = newArray;
        }

        public void Show()
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

        public void ShowPartially(int rowFrom, int columnFrom, int rowTo, int columnTo)
        {
            for (int i = rowFrom - 1; i < rowTo; ++i)
            {
                for (int j = columnFrom - 1; j < columnTo; ++j)
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
    }
}
