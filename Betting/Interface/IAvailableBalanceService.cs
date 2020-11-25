using Betting.Model;
using System;

namespace Betting
{
    public interface IAvailableBalanceService : IObserver<Profit>, IObserver<Bet>, IObserver<Transaction>, IObservable<Balance>
    {
    }
}
