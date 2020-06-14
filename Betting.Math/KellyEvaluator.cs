
namespace Betting.Math
{


    public class KellyEvaluator
    {
        private decimal proportion;
        public KellyEvaluator(decimal proportion = 1.0M)
        {
            this.proportion = proportion;
        }

        public decimal MaxBankRoll(decimal bankRoll, decimal pot, decimal stake, decimal ourWinPercentage)
        {
            return bankRoll * MaxFraction(bankRoll, pot, stake, ourWinPercentage);
        }

        //given our current bankroll, a pot, an amount we’ve already staked, 
        //our win percentage and the mean for the # of players,
        //what is the maximum value we should allow ourselves to bet?
        public decimal MaxNormalisedBankRoll(decimal bankRoll, decimal pot, decimal stake, decimal ourWinPercentage, decimal meanWinPercentage)
        {
            return bankRoll * MaxNormalisedFraction(bankRoll, pot, stake, ourWinPercentage, meanWinPercentage);
        }

        //given a win% and an amount we’ve already staked, whatis the max we can bet
        public decimal MaxNormalisedFraction(decimal bankRoll, decimal pot, decimal totalStaked, decimal ourWinPercentage, decimal meanWinPercentage)
        {
            decimal f = 0.0M;
            decimal proposedBet = bankRoll;
            decimal max = 0.0M;
            while (proposedBet > 0.0M)
            {
                f = NormalisedFraction(bankRoll, pot - totalStaked, proposedBet, ourWinPercentage, meanWinPercentage);
                if (f >= 0.0M)
                    max = f;
                proposedBet -= 1.0M;
            }

            return max;
        }

        //given a win% whatis the max we can bet
        public decimal MaxFraction(decimal bankRoll, decimal pot, decimal totalStaked, decimal ourWinPercentage)
        {
            decimal f = 0.0M;
            decimal proposedBet = bankRoll;
            decimal max = 0.0M;
            while (proposedBet > 0.0M)
            {
                f = Fraction(bankRoll, pot - totalStaked, proposedBet, ourWinPercentage);
                if (f >= 0.0M)
                    max = f;
                proposedBet -= 1.0M;
            }

            return max;
        }

        private decimal NormalisedFraction(decimal bankRoll, decimal potentialWinnings, decimal ourStake, decimal ourWinPercentage, decimal meanWinPercentage)
        {
            decimal delta = ourWinPercentage - meanWinPercentage;
            decimal edgePercentage = delta / meanWinPercentage;

            return Fraction(bankRoll, potentialWinnings, ourStake, edgePercentage);
        }

        private decimal Fraction(decimal bankRoll, decimal potentialWinnings,
                                 decimal ourStake, decimal ourWinPercentage)
        {

            //b:1 i.e., if pot is 100 and call value is 20 and we’ve staked nothing else so far, then 5:1
            decimal b = potentialWinnings / (ourStake);
            decimal f = ((b * ourWinPercentage) - (1 - ourWinPercentage)) / b;

            return f * proportion;
        }
    }


}
