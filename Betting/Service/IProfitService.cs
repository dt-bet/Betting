using Betting.Model;
using System;

namespace Betting
{
    public interface IProfitService : IObserver<Bet>, IObserver<Result>, IObservable<Profit>
    {
    }

    //public class ProfitTrackerFactory
    //{
    //    public static ProfitTracker BuildDefault()
    //    {
    //        return new ProfitTracker(new List<Prediction>(), new List<Result>(), new List<Profit>());
    //    }


    //}



}


