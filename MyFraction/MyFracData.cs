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
}