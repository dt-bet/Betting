

using Betting.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UtilityEnum;
using UtilityHelper;
using UtilityHelper.NonGeneric;

namespace Betting
{
    public class ProfitTrackerWrapper
    {


        public Betting.ProfitTracker GetProfitTrack(IEnumerable<DateTime> Date, IEnumerable<bool> Result, IEnumerable<double> Prediction, IEnumerable<double> Price, double start)
        {
            ProfitTracker profitTracker = null;
            using (var d = Date.GetEnumerator())
            using (var r = Result.GetEnumerator())
            using (var p = Prediction.GetEnumerator())
            using (var prc = Price.GetEnumerator())
            {
                UpdateProfitTrack(profitTracker, d.Current, r.Current, p.Current, prc.Current, start);
            }
            return profitTracker;
        }



        public void UpdateProfitTrack(ProfitTracker profitTracker, DateTime Date, bool Result, double Prediction, double Price, double start)
        {


            profitTracker = profitTracker ?? GetProfitTracker(Date, start);

            //var xx = TrialMatches.Zip(predictions, (a, b) => { if (b > 0) { return a.GetUnitProfitHome() * b; } else return 0; });

            //var yy = xx.Average();


            try
            {
                var week = Date.GetWeekOfYear();
                profitTracker.UpdateWeek(week);

                //var probs = ProbabilityMaths.FromGaussian(predictions[i], 1).Reverse().ToArray();

                profitTracker.MakeBet(Date, Prediction, (decimal)Price, UtilityEnum.Betting.Side.Back);

                profitTracker.ExecuteBet(Date, Result);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "unable to update profit controller");

            }
        }
        private ProfitTracker GetProfitTracker(DateTime Date, double start)
        {
            var profitTracker = new Betting.ProfitTracker(UtilityEnum.Betting.Side.Back, "home");

            profitTracker.Init(Date, (decimal)start);
            return profitTracker;
        }

    }


}

//        static double[] limits = new double[] { -0.5, 0.5 };


//        internal static void ExecuteBets(Bet[] bets, object runningProfits, ref object amountspent)
//        {
//            throw new NotImplementedException();
//        }



//        public static Bet[] MakeBackBets(DateTime date, double[] arbs, int[] runningProfits, byte week, decimal[] prices, double[] percentAtRisk)
//        {
//            Bet[] bets = new Bet[3];
//            string[] contracts = new string[] { "Home", "Draw", "Away" };


//            for (int i = 0; i < 3; i++)
//            {

//                bets[i] = MakeBet(UtilityEnum.Betting.Side.Back, date, arbs[i], runningProfits[i], prices[i], percentAtRisk[i], contracts[i]);
//            }



//            return bets;

//        }




//        public static Bet[] MakeLayBets(DateTime date, double[] unitAmounts, int[] runningProfits, byte week, decimal[] prices, double[] percentAtRisk)
//        {
//            Bet[] bets = new Bet[3];
//            string[] contracts = new string[] { "Home", "Draw", "Away" };


//            for (int i = 0; i < 3; i++)
//            {

//                bets[i] = MakeBet(UtilityEnum.Betting.Side.Lay, date, unitAmounts[i], runningProfits[i], prices[i], percentAtRisk[i], contracts[i]);
//            }
//            return bets;

//        }



//        public static Bet MakeBet(UtilityEnum.Betting.Side side, DateTime date, double unitAmount, double runningProfit, decimal price, double percentAtRisk, string contract)
//        {
//            Bet bet = new Bet();



//            //decimal unitAmount = ProfitMaths.Arbitrage(UtilityEnum.Betting.Side.Back, price, prob)*100;
//            if (UtilityEnum.Betting.Side.Lay == side)
//                unitAmount = -unitAmount;

//            if (unitAmount < 0)
//            {
//                return null;
//            }
//            else
//            {
//                return new Bet
//                {
//                    //e = date,
//                    Price = (double)(price),
//                    //Risk = (decimal)percentAtRisk,
//                    Amount = (unitAmount * percentAtRisk * (double)runningProfit * 0.5), //(double)price

//                    Total = (runningProfit),
//                    Side = side,
//                    ContractName = contract,
//                    //Week = week
//                };
//            }

//        }


//        public static void ExecuteBets(Bet[] bets, int[] pot, ref double[] amountSpent)
//        {
//            //decimal amt = 0;

//            for (int i = 0; i < bets.Length; i++)
//            {
//                ExecuteBet(bets[i], pot[i], ref amountSpent[i]);

//            }

//        }


//        public static void ExecuteBet(Bet bets, double pot, ref double amountSpent)
//        {
//            //decimal amt = 0;


//            if (bets != null)
//            {
//                if (amountSpent + bets.Amount > pot * 100)
//                {
//                    bets.Execution = UtilityEnum.Execution.Failure;
//                    bets.Amount = 0;
//                }
//                else if (bets.Amount > 000)
//                {
//                    bets.Execution = UtilityEnum.Execution.Success;

//                    //bets[i].Amount = bets[i].Amount;

//                }

//                amountSpent = +bets.Amount;
//            }

//        }









//        public static double[] CalculateProfits<T>(Bet[] bets, T match,Func<T, DateTime> date, Func<T, string> result)
//        {
//           double[] profits = new double[6];
//            ContractType sresult = result(match).ToContract();

//            for (int i = 0; i < bets.Count(); i++)
//                profits[i] = CalculateProfit(bets[i], date(match), sresult);


//            return profits;
//        }

//        public static double CalculateProfit(Bet bet, DateTime date, bool result)
//        {

//            if (bet != null)
//            {
//                bet.Result = result ? Resolution.For : Resolution.Against;

//                bet.Execution = Execution.Success;

//                bet.Profit = (double)bet.GetProfit();

//                bet.Placed = date;

//                bet.Total += bet.Profit;

//                return bet.Profit;

//            }
//            return 0;

//        }

//        public static double CalculateProfit(Bet bet, DateTime date, ContractType sresult)
//        {

//            if (bet != null && sresult == ContractType.None)
//            {

//                Resolution Resolution = bet.ContractName.Equals(sresult.ToString().ToLower()) ? Resolution.For : Resolution.Against;

//                bet.Result =  Resolution;

//                bet.Execution = Execution.Success;

//                bet.Profit = (double)bet.GetProfit();

//                bet.Placed = date;

//                bet.Total += bet.Profit;

//                return bet.Profit;

//            }
//            return 0;

//        }


//        public static double CalculateProfit(Bet bet, DateTime date, double unitprofit)
//        {

//            if (bet != null )
//            {


//                bet.Result = unitprofit > 0 ? Resolution.For : Resolution.Against;

//                bet.Execution = Execution.Success;

//                bet.Profit = bet.Amount * unitprofit;

//                bet.Placed = date;

//                bet.Total += bet.Profit;

//                return bet.Profit;

//            }
//            return 0;

//        }


//    }




//}
