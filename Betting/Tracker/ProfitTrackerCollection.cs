using Betting.Common;
using Betting.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using UtilityEnum;
using UtilityHelper;
using UtilityStruct;

namespace Betting
{


    public interface IProfitTrackerCollection
    {

        ObservableCollection<ProfitTracker> Trackers { get; }

    }



    public class ProfitTrackerCollection<T>:IProfitTrackerCollection
    {
        static readonly string[] contracts = new string[] { "Home", "Draw", "Away" };


        public ObservableCollection<ProfitTracker> Trackers { get; }


        public ProfitTrackerCollection(int initialValue, DateTime start)
        {
            Trackers = new ObservableCollection<ProfitTracker>
                (contracts.Select(_ => new ProfitTracker(initialValue, start, UtilityEnum.Betting.Side.Back, _)).Concat(
                contracts.Select(_ => new ProfitTracker(initialValue, start, UtilityEnum.Betting.Side.Lay, _)))
                );


        }

        public void UpdateWeek(byte week)
        {

            for (int i = 0; i < Trackers.Count; i++)
            {
                Trackers[i].UpdateWeek(week);
            }
        }




        public void Execute(T match, Func<T, DateTime> date, Func<T, string> result)
        {

            for (int i = 0; i < Trackers.Count; i++)
            {
                Trackers[i].ExecuteBet(date(match), (result(match)).ToContract());
            }


        }




        public void MakeBets(T match, Func<T, DateTime> date, double[] arb, double[] prob, Func<T, Probability[]> backprices, Func<T, Probability[]> layprices)
        {
            var backPrices = backprices(match);
            var layPrices = layprices(match);

            for (int i = 0; i < 3; i++)
            {
                arb[i] = arb[i] - (double)(1m/backPrices[i]);

                Trackers[i].MakeBet(date(match), arb[i], backPrices[i], UtilityEnum.Betting.Side.Back);

            }
            for (int i = 3; i < 6; i++)
            {
                Trackers[i].MakeBet(date(match), -arb[i - 3], layPrices[i - 3] , UtilityEnum.Betting.Side.Lay);

            }
        }


    }

}
