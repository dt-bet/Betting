using Betting.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Betting
{


    public class BalanceService : IBalanceService
    {

        //ICollection<Profit> Profits;

        //ICollection<Transaction> Transactions;

        private Balance balance = new Balance(); 

        private readonly ICollection<IObserver<Balance>> observers = new List<IObserver<Balance>>();


        //public BalanceService(ICollection<Profit> profits, ICollection<Transaction> transactions)
        //{
        //    this.Profits = profits;
        //    this.Transactions = transactions;

        //}


        public BalanceService() /*: this(new List<Profit>(), new List<Transaction>())*/
        {

        }

        public void OnNext(Profit profit)
        {
            //Profits.Add(profit);

            balance = new Balance { Date = DateTime.Now, Amount = balance.Amount + profit.Amount };

            foreach (var observer in observers)
            {
                observer.OnNext(balance);
            }

        }

        public void OnNext(Transaction transaction)
        {
            //Transactions.Add(transaction);

            balance = new Balance { Date = DateTime.Now, Amount = balance.Amount + transaction.Amount };

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
