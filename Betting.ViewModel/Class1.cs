




namespace Betting.Math
{
    using System.Collections.Generic;

    public class Class1
    {
        double balance;

        public Class1(int balance)
        {
            this.balance = balance;
        }

        public IEnumerable<double> GetValues(double a, double b, double c)
        {
            while (true)
            {
                balance = Next(balance, a, b, c);
                yield return balance;
            }
        }


        private double Next(double balance, double percentage, double win, double sigma)
        {

            var trandom = Troschuetz.Random.TRandom.New();
            return balance + (percentage * balance) * (trandom.Normal(win, sigma));

        }
    }
}
