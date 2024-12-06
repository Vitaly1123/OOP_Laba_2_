using Matrix;
using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        try
        {
            // Створення матриці з двовимірного масиву
            double[,] array = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            MyMatrix matrix1 = new MyMatrix(array);
            Console.WriteLine("Матриця 1:");
            Console.WriteLine(matrix1);

            // Створення матриці з "зубчастого" масиву
            double[][] jaggedArray = new double[][]
            {
                new double[] { 1, 2 },
                new double[] { 3, 4 },
                new double[] { 5, 6 }
            };
            MyMatrix matrix2 = new MyMatrix(jaggedArray);
            Console.WriteLine("\nМатриця 2:");
            Console.WriteLine(matrix2);

            // Додавання матриць
            MyMatrix matrix3 = new MyMatrix(array);
            MyMatrix sumMatrix = matrix1 + matrix3;
            Console.WriteLine("\nСума Матриці 1 і Матриці 3:");
            Console.WriteLine(sumMatrix);

            // Множення матриць
            double[,] arrayB = {
                { 1, 0 },
                { 0, 1 },
                { 1, 1 }
            };
            MyMatrix matrixB = new MyMatrix(arrayB);
            MyMatrix productMatrix = matrix1 * matrixB;
            Console.WriteLine("\nДобуток Матриці 1 і Матриці B:");
            Console.WriteLine(productMatrix);

            // Транспонування матриці
            Console.WriteLine("\nТранспонована Матриця 2:");
            MyMatrix transposedMatrix = matrix2.GetTransponedCopy();
            Console.WriteLine(transposedMatrix);

            // Зміна матриці шляхом транспонування на місці
            Console.WriteLine("\nМатриця 2 після транспонування на місці:");
            matrix2.TransponeMe();
            Console.WriteLine(matrix2);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
