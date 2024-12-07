using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        MyFrac frac1 = new MyFrac(3, 4);
        MyFrac frac2 = new MyFrac(5, 6);
        Console.WriteLine($"Дріб 1: {frac1}");
        Console.WriteLine($"Дріб 2: {frac2}");

        MyFrac sum = frac1 + frac2;
        Console.WriteLine($"Сума: {sum} З цілою частиною: {sum.ToStringWithIntPart()}");

        MyFrac difference = frac1 - frac2;
        Console.WriteLine($"Різниця: {difference} З цілою частиною: {difference.ToStringWithIntPart()}");

        MyFrac product = frac1 * frac2;
        Console.WriteLine($"Добуток: {product} З цілою частиною: {product.ToStringWithIntPart()}");

        MyFrac divide = frac1 / frac2;
        Console.WriteLine($"Частка: {divide} З цілою частиною:  {divide.ToStringWithIntPart()}");

        Console.WriteLine($"Дріб 1 у вигляді десяткового числа: {frac1.ToDouble()}");
        Console.WriteLine($"Дріб 2 у вигляді десяткового числа: {frac2.ToDouble()}");

        int n = 5;
        MyFrac seriesSum = MyFrac.CalcSum(n);
        Console.WriteLine($"Сума ряду (від 1 до {n}): {seriesSum} З цілою частиною: {seriesSum.ToStringWithIntPart()}");

        MyFrac seriesProduct = MyFrac.CalcSum2(n);
        Console.WriteLine($"Добуток ряду (від 1 до {n}): {seriesProduct} З цілою частиною: {seriesProduct.ToStringWithIntPart()}");
    }
}
