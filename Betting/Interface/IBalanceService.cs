using Betting.Model;
using System;

namespace Betting
{
    public interface IBalanceService : IObserver<Profit>, IObserver<Transaction>, IObservable<Balance>
    {
    }
}
