using Troschuetz.Random;

namespace Betting.ViewModel
{
    class BetsFactory
    {
        private readonly Troschuetz.Random.TRandom trandom;

        public BetsFactory(TRandom trandom)
        {
            this.trandom = trandom;
        }

        public (bool? winLose, double odd, double unitProfit) Next(double profitablity, double win, double sigma)
        {
            double odd = trandom.Normal(1 / win, sigma);
            var tRandom = trandom.NextDouble();
            var winLoss = (tRandom != win ? tRandom < (win + profitablity) ? (bool?)true : false : null);
            var unitProfit = winLoss.HasValue ? winLoss.Value ? odd - 1 : -1 : 0;
            return (winLoss, odd, unitProfit);
        }
    }
}

