using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public partial class MyMatrix
    {
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {

            if (a.Height != b.Height || a.Width != b.Width)
            {
                throw new ArgumentException("Матриця повинна бути однакового розміру");
            }

            MyMatrix result = new MyMatrix(a);

            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }

            return result;
        }

        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            if (a.Height != b.Height || a.Width != b.Width)
            {
                throw new ArgumentException("Матриця повинна бути однакового розміру");
            }
            MyMatrix result = new MyMatrix(new double[a.Height, b.Width]);

            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < a.Width; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }
    }
}
