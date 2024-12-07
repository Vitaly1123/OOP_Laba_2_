using System;

partial class MyFrac
{
    protected long nom, denom;
    public MyFrac(long nom, long denom)
    {
        int sign = 1;
        if (nom / denom < 0)
        {
            sign = -1;
        }
        long t_nom = Math.Abs(nom);
        long t_denom = Math.Abs(denom);
        long gcd;
        while (true)
        {
            if (t_nom % t_denom == 0)
            {
                gcd = t_denom;
                break;
            }
            else if (t_denom % t_nom == 0)
            {
                gcd = t_nom;
                break;
            }
            if (t_nom > t_denom)
            {
                t_nom %= t_denom;
            }
            else t_denom %= t_nom;
        }
        this.nom = Math.Abs(nom) / gcd * sign;
        this.denom = Math.Abs(denom) / gcd;
    }
    public string ToStringWithIntPart()
    {
        string minus = "";
        if (this.nom < 0) minus = "-";
        long intPart = Math.Abs(this.nom) / this.denom;
        long nom = Math.Abs(this.nom) - intPart * this.denom;
        if (nom == 0)
        {
            return $"{minus}({intPart}/{this.denom})";
        }
        if (intPart == 0)
        {
            return $"{minus}({new MyFrac(nom, this.denom)})";
        }
        return $"{minus}({intPart}+{new MyFrac(nom, this.denom)})";
    }
    public override string ToString()
    {
        return nom + "/" + denom;
    }
}