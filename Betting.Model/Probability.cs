using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.Model
{
    //public struct Probability
    //{


    //    public Probability(decimal val) : this()
    //    {
    //        if (val < 1 && val > 0)
    //        {
    //            this.Decimal = val;
    //        }
    //        else
    //        {
    //            throw new ArgumentException("value must be between 0 and 1");
    //        }
    //    }



    //    // User-defined conversion from Probability to decimal
    //    public static implicit operator decimal(Probability i)
    //    {
    //        return i.Decimal;
    //    }

    //    public static implicit operator Probability(decimal i)
    //    {
    //        return new Probability(i);
    //    }

    //    public decimal Decimal { get; }

    //    public int Percent => (int)(Decimal * 100m);

    //    /// <summary>
    //    /// EuropeanOdd
    //    /// </summary>
    //    public decimal EuropeanOdd => 1 / Decimal;


    //    public int MoneyLine
    //    {
    //        get
    //        {
    //            int percent = Percent;
    //            if (Decimal > 0.5m)
    //                return (int)(-(percent / (100m - percent)) * 100);
    //            else
    //                return (int)(((100m - percent) / percent) * 100);
    //        }
    //    }


    //    public (int, int) EnglishOdd
    //    {
    //        get { var fraction = GetFraction((double)Decimal);
    //            return ((fraction.Item1 + fraction.Item2), fraction.Item2); }
    //    }



    //    //https://stackoverflow.com/questions/14320891/convert-percentage-to-nearest-fraction
    //    // answered Jan 14 '13 at 16:44    DasKrümelmonster
    //    private (int, int) GetFraction(double value, double tolerance = 0.02)
    //    {
    //        double f0 = 1 / value;
    //        double f1 = 1 / (f0 - Math.Truncate(f0));

    //        int a_t = (int)Math.Truncate(f0);
    //        int a_r = (int)Math.Round(f0);
    //        int b_t = (int)Math.Truncate(f1);
    //        int b_r = (int)Math.Round(f1);
    //        int c = (int)Math.Round(1 / (f1 - Math.Truncate(f1)));

    //        if (Math.Abs(1.0 / a_r - value) <= tolerance)
    //            return (1, a_r);
    //        else if (Math.Abs(b_r / (a_t * b_r + 1.0) - value) <= tolerance)
    //            return (b_r, a_t * b_r + 1);
    //        else
    //            return (c * b_t + 1, c * a_t * b_t + a_t + c);
    //    }
    //}


    //public static class ProbabilityHelper
    //{
    //    public static Probability GetFromMoneyLine(int value)
    //    {
    //        if (value < -100 || value > 10)
    //        {
    //            return (value < 0) ?
    //                   new Probability((-value) / (-(value) + 100m)) :
    //                new Probability(100m / value + 100);
    //        }
    //        throw new ArgumentException("Value must be less than -100 or greater than 100.");
    //    }

    //    public static Probability GetFromEnglishOdd((int, int) value) => ((value.Item1 + value.Item2) / value.Item2) - 1;

    //    public static Probability GetFromEuropeanOdd((int, int) value) => new Probability(((value.Item1 + value.Item2) / value.Item2) - 1);

    //    public static Probability GetFromPercent(int value) => new Probability(value / 100m);

    //}


}
