using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

partial class MyFrac
{
    public double ToDouble()
    {
        return (double)this.nom / this.denom;
    }

    public static MyFrac operator +(MyFrac f1, MyFrac f2)
    {
        return new MyFrac(f1.nom * f2.denom + f1.denom * f2.nom, f1.denom * f2.denom);
    }

    public static MyFrac operator -(MyFrac f1, MyFrac f2)
    {
        return new MyFrac(f1.nom * f2.denom - f1.denom * f2.nom, f1.denom * f2.denom);
    }

    public static MyFrac operator *(MyFrac f1, MyFrac f2)
    {
        return new MyFrac(f1.nom * f2.nom, f1.denom * f2.denom);
    }

    public static MyFrac operator /(MyFrac f1, MyFrac f2)
    {
        return new MyFrac(f1.nom * f2.denom, f1.denom * f2.nom);
    }

    public static MyFrac CalcSum(int n)
    {
        MyFrac fr = new(0, 1);
        for (long i = 1; i <= n; i++)
        {
            fr += new MyFrac(1, i * (i + 1));
        }
        return fr;
    }
    public static MyFrac CalcSum2(int n)
    {
        if (n == 1) return new MyFrac(1, 1);
        MyFrac fr = new(1, 1);
        for (long i = 2; i <= n; i++)
        {
            fr *= (new MyFrac(1, 1) - new MyFrac(1, i * i));
        }
        return fr;
    }
}