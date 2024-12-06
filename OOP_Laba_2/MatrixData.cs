using System;
using System.Text;

namespace Matrix
{
    public partial class MatrixData
    {
        protected double[,] matrix;
        protected double? cachedDet = null;
        protected bool isMod = true;
        protected void InvalidateCache()
        {
            isMod = true;
            cachedDet = null;
        }
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
        public MyMatrix(string[] str)
        {
            int rows = str.Length;
            int cols = str[0].Trim().Split().Length;
            matrix = new double[rows, cols];
            InvalidateCache();
            for (int i = 0; i < rows; i++)
            {
                double[] tempArr = Array.ConvertAll(str[i].Trim().Split(), double.Parse);
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = tempArr[j];
                }
            }
        }
        public MyMatrix(string input)
        {
            string[] str = input.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            string[][] strMatrix = new string[str.Length][];

            for (int i = 0; i < str.Length; i++)
            {
                strMatrix[i] = str[i].Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
            }
            int rows = strMatrix.Length;
            int cols = strMatrix[0].Length;

            matrix = new double[rows, cols];
            InvalidateCache();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = double.Parse(strMatrix[i][j]);
                }
            }
        }
        public int getHeight() => Height;
        public int getWidth() => Width;
        public double this[int index1, int index2]
        {
            get => matrix[index1, index2];
            set
            {
                matrix[index1, index2] = value;
                InvalidateCache();
            }
        }
        public double getElement(int row, int col)
        {
            return matrix[row, col];
        }
        public void setElement(int row, int col, double value)
        {
            matrix[row, col] = value;
            InvalidateCache();
        }

    }
}