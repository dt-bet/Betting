using Betting.Model;
using System;

namespace Betting
{
    public interface IBetService : IObserver<Recommendation>, IObserver<Balance>, IObservable<Bet>
    {
    }


}


