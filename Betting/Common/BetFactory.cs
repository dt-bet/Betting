using Betting.Model;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityStruct;

namespace Betting
{
    public static class BetFactory
    {
        //static double[] limits = new double[] { -0.5, 0.5 };
        static string[] contracts = new string[] { "Home", "Draw", "Away" };


        public static IEnumerable<Bet> MakeBackBets(DateTime date, NodaMoney.Money[] arbs, NodaMoney.Money[] runningProfits, byte week, Probability[] prices, double[] percentAtRisk)
        {
            for (int i = 0; i < 3; i++)
            {
                yield return Make(UtilityEnum.Betting.Side.Back, date, arbs[i], runningProfits[i], prices[i], percentAtRisk[i], contracts[i]);
            }
        }


        public static IEnumerable<Bet> MakeLayBets(DateTime date, NodaMoney.Money[] unitAmounts, NodaMoney.Money[] runningProfits, byte week, Probability[] prices, double[] percentAtRisk)
        {
            for (int i = 0; i < 3; i++)
            {
                yield return Make(UtilityEnum.Betting.Side.Lay, date, unitAmounts[i], runningProfits[i], prices[i], percentAtRisk[i], contracts[i]);
            }
        }



        public static Bet Make(UtilityEnum.Betting.Side side, DateTime date, NodaMoney.Money unitAmount, NodaMoney.Money runningProfit, Probability price, double percentAtRisk, string contract)
        {
            //decimal unitAmount = ProfitMaths.Arbitrage(UtilityEnum.Betting.Side.Back, price, prob)*100;
            if (UtilityEnum.Betting.Side.Lay == side)
                unitAmount = -unitAmount;

            if (unitAmount < 0)
                return null;
            else
            {
                return new Bet
                {
                    //e = date,
                    Price = (price),
                    //Risk = (decimal)percentAtRisk,
                    Amount = NodaMoney.Money.Multiply(unitAmount.Amount * runningProfit * 0.5m,(decimal)percentAtRisk), //(double)price

                    Total = (runningProfit),
                    Side = side,
                    ContractName = contract,
                    //Week = week
                };
            }

        }


    }
}
