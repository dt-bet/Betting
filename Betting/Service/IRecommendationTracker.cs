using Betting.Model;
using System;

namespace Betting
{
    public interface IRecommendationTracker : IObserver<Prediction>, IObserver<Price>, IObservable<Recommendation>
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


