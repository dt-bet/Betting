
using Betting.Common;
using Betting.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilityHelper;
using UtilityStruct;

namespace Betting
{
   public class ProfitCalculator
    {


        public static Betting.ProfitTrackerCollection<T> GetProfitTrackCollection<T>(IList<T> TrialMatches, Func<T, DateTime> startTime, Func<T, Probability[]> backOdds, Func<T, Probability[]> layOdds, double[] predictions, Func<T, string> result)
        {
            var ProfitTrackerCollection = new Betting.ProfitTrackerCollection<T>(10000, startTime(TrialMatches.First()));

            for (int i = 0; i < TrialMatches.Count(); i++)
            {
                try
                {
                    var week = startTime(TrialMatches[i]).GetWeekOfYear();
                    ProfitTrackerCollection.UpdateWeek(week);

                    var probs = Betting.Math.ProbabilityHelper.FromGaussian(predictions[i], 1).Reverse().ToArray();


                    ProfitTrackerCollection.MakeBets(TrialMatches[i], startTime, probs.Select(_=>(double)_.Decimal).ToArray(), probs.Select(_ => 0.00001d).ToArray(), match => backOdds(match), match => layOdds(match));

                    ProfitTrackerCollection.Execute(TrialMatches[i], a => startTime(a), a => result(a));

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "unable to update profit controller");

                }
            }

            return ProfitTrackerCollection;
        }


        public static Betting.ProfitTracker GetProfitTrack<T>(IList<T> TrialMatches, Func<T, DateTime> startTime, Func<T, decimal> odd, UtilityEnum.Betting.Side side, Func<T,double> prediction, Func<T, string> result,string contract)
        {
            var ProfitTracker = new Betting.ProfitTracker(10000, startTime(TrialMatches.First()),side,contract);
            for (int i = 0; i < TrialMatches.Count(); i++)
            {
                try
                {
                    var week = startTime(TrialMatches[i]).GetWeekOfYear();
                    ProfitTracker.UpdateWeek(week);
                    ProfitTracker.MakeBet(startTime(TrialMatches[i]), prediction(TrialMatches[i]), odd(TrialMatches[i]) ,side);
                    ProfitTracker.ExecuteBet(startTime(TrialMatches[i]), (result(TrialMatches[i])).ToContract());

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "unable to update profit controller");

                }

            }

            return ProfitTracker;
        }



        public static Betting.ProfitTracker GetProfitTrack<T>(IList<T> TrialMatches, Func<T, DateTime> startTime, Func<T, decimal> odd, UtilityEnum.Betting.Side side, Func<T, double> prediction, Func<T, double> unitprofit,string contract)
        {
            var ProfitTracker = new Betting.ProfitTracker(10000, startTime(TrialMatches.First()), side, contract);
            for (int i = 0; i < TrialMatches.Count(); i++)
            {
                try
                {
                    var week = startTime(TrialMatches[i]).GetWeekOfYear();
                    ProfitTracker.UpdateWeek(week);

                    ProfitTracker.MakeBet(startTime(TrialMatches[i]), prediction(TrialMatches[i]), odd(TrialMatches[i]), side);

                    ProfitTracker.ExecuteBet(startTime(TrialMatches[i]),unitprofit(TrialMatches [i])>0);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "unable to update profit controller");

                }

            }

            return ProfitTracker;
        }
    }
}
