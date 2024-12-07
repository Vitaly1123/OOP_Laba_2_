using System;
using System.Text;
using System.Xml.Linq;

namespace Matrix
{
    public partial class MyMatrix
    {
        protected double[,] matrix;
        public int Height //row
        {
            get => matrix.GetLength(0);
        }
        public int Width // col
        {
            get => matrix.GetLength(1);
        }
        public MyMatrix(MyMatrix other)
        {
            this.matrix = (double[,])other.matrix.Clone();
        }
        public MyMatrix(double[,] multiDimensionsMatrix)
        {
            this.matrix = (double[,])multiDimensionsMatrix.Clone();
        }
        public MyMatrix(double[][] jaggedMatrix)
        {
            int height = jaggedMatrix.Length;
            int width = jaggedMatrix[0].Length;
            for (int i = 0; i < height; i++)
            {
                if (jaggedMatrix[i].Length != width)
                {
                    throw new ArgumentException("Усі підмасиви повинні мати однакову кількість елементів.");
                }
            }
            matrix = new double[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = jaggedMatrix[i][j];
                }
            }
        }
        public MyMatrix(string[] rows)
        {
            int rowCount = rows.Length;
            int colCount = rows[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;

            matrix = new double[rowCount, colCount];
            for (int i = 0; i < rowCount; i++)
            {
                var rowValues = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (rowValues.Length != colCount)
                    throw new ArgumentException("Рядки повинні мати однакову кількість чисел.");

                for (int j = 0; j < colCount; j++)
                    matrix[i, j] = double.Parse(rowValues[j]);
            }
        }

        // Конструктор: створення з рядка
        public MyMatrix(string matrixString) : this(matrixString.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
        {
        }

        public int getHeight() => Height;
        public int getWidth() => Width;
        public double this[int index1, int index2]
        {
            get => matrix[index1, index2];
            set
            {
                matrix[index1, index2] = value;
            }
        }
        public double getElement(int row, int col)
        {
            return matrix[row, col];
        }
        public void setElement(int row, int col, double value)
        {
            matrix[row, col] = value;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    sb.Append(matrix[i, j] + "\t");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }


    }

}