using Betting.Model;
using System;

namespace Betting
{
    public interface IRecommendationService : IObserver<Prediction>, IObserver<Price>, IObservable<Recommendation>
    {
    }
}


