using Betting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Betting
{


    public class BetService : IBetService
    {

        //ICollection<Recommendation> Recommendations;

        //ICollection<Balance> Balances;

        private readonly ICollection<IObserver<Bet>> observers = new List<IObserver<Bet>>();

        Balance balance;


        Recommendation recommendation;

        //public BetService(ICollection<Recommendation> recommendations, ICollection<Balance> predicates)
        //{
        //    Recommendations = recommendations;
        //    Balances = predicates;

        //}


        public BetService()//:this(new List<Recommendation>(),new List<Balance>())
        {

        }

        public void OnNext(Recommendation recommendation)
        {
  
             //Recommendations.Add(recommendation);

            if (this.balance?.Amount.Amount < (recommendation).Value)
            {
                var bet = new Bet();
                foreach (var observer in observers)
                {
                    observer.OnNext(bet);
                }
            }

            this.recommendation = recommendation;
        }

        public void OnNext(Balance balance)
        {
            //Balances.Add(balance);

            if ((decimal)balance.Amount < this.recommendation.Value)
            {
                var bet = new Bet();
                foreach (var observer in observers)
                {
                    observer.OnNext(bet);
                }
            }

            this.balance = balance;
        }




        public void OnCompleted()
        {
            //throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe(IObserver<Bet> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber<Bet>(observers, observer);
        }

    }


}


