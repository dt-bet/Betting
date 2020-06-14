

using Betting.Math;
using Betting.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UtilityEnum;
using UtilityEnum.Betting;
using UtilityMath;
using UtilityStruct;

namespace Betting
{
    public static class ProfitHelper
    {

        public static IEnumerable<(ContractType, decimal)> GetProfit(int diff, (double Home, double Draw, double Away) odds, (double Home, double Draw, double Away) prediction)
        {


            if (prediction.Home > 0 && prediction.Draw > 0 && prediction.Away > 0 && odds.Home > 0 && odds.Draw > 0 && odds.Away > 0)
            {
                //var perfectOdds = GetPerfectOdds(odds.Home, odds.Draw, odds.Away);
                var perfectOdds = (odds.Home, odds.Draw, odds.Away);
                decimal winFraction = 1m;

                Odd odd = new Odd(Odd.PriceType.Bid, new UtilityStruct.Probability(perfectOdds.Home / 100d));
                Resolution resolution = diff > 0 ? Resolution.For : Resolution.Against;
                //if(homePrediction> perfectOdds.Home)
                yield return (ContractType.Home, ((decimal)prediction.Home) * GetUnitProfit(odd, resolution, winFraction));

                odd = new Odd(Odd.PriceType.Bid, new UtilityStruct.Probability(perfectOdds.Draw / 100d));
                resolution = diff == 0 ? Resolution.For : Resolution.Against;
                //if (drawPrediction > perfectOdds.Draw)
                yield return (ContractType.Draw, ((decimal)prediction.Draw) * GetUnitProfit(odd, resolution, winFraction));

                odd = new Odd(Odd.PriceType.Bid, new UtilityStruct.Probability(perfectOdds.Away / 100d));
                resolution = diff < 0 ? Resolution.For : Resolution.Against;
                //if (awayPrediction > perfectOdds.Away)
                yield return (ContractType.Away, ((decimal)prediction.Away) * Betting.ProfitHelper.GetUnitProfit(odd, resolution, winFraction));
            }
        }






        public static Resolution ToSuccess(this ContractType oddC, ContractType outcome) => (oddC == outcome) ? Resolution.For : Resolution.Against;



        public static NodaMoney.Money[] CalculateProfits<T>(Bet[] bets, T match, Func<T, DateTime> date, Func<T, string> result)
        {
            NodaMoney.Money[] profits = new NodaMoney.Money[6];

            ContractType sresult = (ContractType)System.Enum.Parse(typeof(ContractType), result(match));

            for (int i = 0; i < bets.Count(); i++)
                profits[i] = CalculateProfit(bets[i], date(match), sresult);


            return profits;
        }

        public static NodaMoney.Money CalculateProfit(Bet bet, DateTime date, bool result)
        {

            if (bet != null)
            {
                bet.Result = result ? Resolution.For : Resolution.Against;
                bet.Execution = Execution.Success;
                bet.Profit = bet.GetProfit();
                bet.Placed = date;
                bet.Total += bet.Profit;
                return bet.Profit;

            }
            return 0;

        }

        public static NodaMoney.Money CalculateProfit(Bet bet, DateTime date, ContractType sresult)
        {
            if (bet != null && sresult == ContractType.None)
            {
                Resolution Resolution = bet.ContractName.Equals(sresult.ToString().ToLower()) ? Resolution.For : Resolution.Against;
                bet.Result = Resolution;
                bet.Execution = Execution.Success;
                bet.Profit = bet.GetProfit();
                bet.Placed = date;
                bet.Total += bet.Profit;

                return bet.Profit;

            }
            return 0;

        }


        public static NodaMoney.Money CalculateProfit(Bet bet, DateTime date, double unitprofit)
        {

            if (bet != null)
            {
                bet.Result = unitprofit > 0 ? Resolution.For : Resolution.Against;
                bet.Execution = Execution.Success;
                bet.Profit = new NodaMoney.Money((double)bet.Amount * unitprofit);
                bet.Placed = date;
                bet.Total += bet.Profit;
                return bet.Profit;
            }
            return 0;
        }

        public static double Arbitrage(this Odd odd, double probability)
        {
            // based on Kelly-Kriterian i.e potential gain from a unit bet - potential loss from unit bet multiplied by how likely it is to occur (inverse of price)
            // see:https://www.pinnacle.com/en/betting-articles/betting-strategy/how-to-use-kelly-criterion-for-betting#height
            //  https://github.com/laholmes/QuantShorts


            return (odd.IsOffer() ? -1 : 1) * ((double)odd.AdjustedPrice() * (probability) - (1 - probability));

        }


        public static decimal AmountatRisk(double arbitrage, decimal percentAtRisk, decimal sumProfits)
        {
            if (arbitrage > 0)
                return (decimal)arbitrage * percentAtRisk * (decimal)sumProfits;
            else
                return 0;
        }


        public static decimal GetProfit(this Odd odd, decimal amtAtRisk, Resolution result, decimal winFraction)
        {
            return amtAtRisk * odd.GetUnitProfit(result, winFraction);
        }


        public static decimal GetUnitProfit(this Odd odd, Resolution result, decimal winFraction)
        {
            decimal x = 0;

            switch (odd.Type)
            {
                case (Odd.PriceType.Bid):
                    if (result == Resolution.For)
                        x = (odd - 1m);
                    else
                        x = -1;
                    break;
                case (Odd.PriceType.Offer):
                    if (result == Resolution.Against)
                        x = 1;
                    else
                        x = -(odd - 1m);
                    break;
            }

            if (x > 0) x *= winFraction;

            return x;

        }

    }

}






