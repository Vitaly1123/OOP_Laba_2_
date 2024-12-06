using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Matrix
{
    public partial class MyMatrix
    {
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            // Перевірка, чи матриці мають однакові розміри
            if (a.Height != b.Height || a.Width != b.Width)
                throw new InvalidOperationException("Розміри матриць повинні співпадати для додавання.");

            // Створення нової матриці для результату
            var result = new MyMatrix(new double[a.Height, a.Width]);

            // Прохід по всіх елементах і виконання додавання
            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < a.Width; j++)
                {
                    // Додавання відповідних елементів
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            // Повернення матриці-результату
            return result;
        }


        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            // Перевірка на сумісність розмірів для множення
            if (a.Width != b.Height)
                throw new InvalidOperationException("Розміри матриць не підходять для множення.");

            // Створення нової матриці для результату
            var result = new MyMatrix(new double[a.Height, b.Width]);

            // Прохід по рядках матриці a та стовпцях матриці b
            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    // Ініціалізація елемента матриці-результату
                    result[i, j] = 0;

                    // Обчислення значення через добуток відповідних елементів
                    for (int k = 0; k < a.Width; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return result;
        }


        private double[,] GetTransponedArray()
        {
            var transposed = new double[Width, Height];
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    transposed[j, i] = matrix[i, j];

            return transposed;
        }

        public MyMatrix GetTransponedCopy()
        {
            return new MyMatrix(GetTransponedArray());
        }

        public void TransponeMe()
        {
            matrix = GetTransponedArray();
        }
    }

}