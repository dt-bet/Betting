using Betting.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Betting
{


    public class AvailableBalanceService : IAvailableBalanceService
    {

        //ICollection<Bet> Bets;

        //ICollection<Balance> Balances;

        private NodaMoney.Money Amount;

        private NodaMoney.Money Spent;
        private Balance balance;
        private readonly ICollection<IObserver<Balance>> observers = new List<IObserver<Balance>>();


        public AvailableBalanceService(/*ICollection<Balance> balances, ICollection<Bet> bets*/)
        {
            //this.Bets = bets;
            //this.Balances = balances;

        }


        //public AvailableBalanceService() : this(new List<Balance>(), new List<Bet>())
        //{

        //}

        public void OnNext(Transaction transaction)
        {
            Amount += balance.Amount;
            balance = new Balance { Date = DateTime.Now, Amount = Amount-Spent};

            foreach (var observer in observers)
            {
                observer.OnNext(balance);
            }

        }

        public void OnNext(Bet bet)
        {
            Spent+= bet.Amount;
            balance = new Balance { Date = DateTime.Now, Amount = Amount - Spent };

            foreach (var observer in observers)
            {
                observer.OnNext(balance);

            }
        }

        public void OnNext(Profit profit)
        {
            Amount += profit.Amount;
            balance = new Balance { Date = DateTime.Now, Amount = Amount - Spent };

            foreach (var observer in observers)
            {
                observer.OnNext(balance);

            }
        }


        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe(IObserver<Balance> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber<Balance>(observers, observer);
        }

    }
}
