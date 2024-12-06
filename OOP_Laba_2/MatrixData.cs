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
    }
}
