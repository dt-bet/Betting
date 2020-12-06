using System.Collections.Generic;

namespace Betting.ViewModel
{
    public class BalanceFactory
    {
        private double balance;
        private readonly Troschuetz.Random.TRandom trandom;
        private readonly BetsFactory profitFactory;

        public BalanceFactory(double initialbalance)
        {
            this.balance = initialbalance;
            trandom = Troschuetz.Random.TRandom.New();
            profitFactory = new BetsFactory(trandom);
        }

        public IEnumerable<double> GetValues(double percentage, double profitablity, double win, double sigma)
        {
            while (true)
            {
                var (_, odd, unitProfit) = profitFactory.Next(profitablity, win, sigma);
                balance = Next(balance, percentage, unitProfit, odd);
                yield return balance;
            }

            double Next(double balance, double percentage, double unitProfit, double odd)
            {

                return balance + (percentage * balance) * unitProfit / odd;
            }

        }

    }
}

