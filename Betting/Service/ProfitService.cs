using Betting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betting.Enum;

namespace Betting
{


    public class ProfitService// : IProfitService
    {
        ICollection<Bet> bets;

        //ICollection<Result> results;


        private readonly ICollection<IObserver<Profit>> observers = new List<IObserver<Profit>>();



        //public ProfitService(ICollection<Bet> bets, ICollection<Result> results)
        //{
        //    this.bets = bets;
        //    this.results = results;
        //}

        public ProfitService()//:this(new List<Bet>(), new List<Result>())
        {
            bets = new List<Bet>();
        }

        public void OnNext(Bet prediction)
        {
            bets.Add(prediction);



            //var single = (Results.SingleOrDefault(_ => _.ParentKey == prediction.ParentKey));
            //if (single != null)
            //{
            //    var profit = prediction.Amount * single.Value;

            //    Profits.Add(new DAL.Profit { Amount = profit, Date = prediction.Date, Target = single.Team, ParentKey = single.ParentKey });
            //}
        }

        //public void OnNext(Result result)
        //{
        //    //results.Add(result);

        //    var bet = bets.Last();

        //    Profit profit = null;

        //    if(bet.Side==TradeSide.Back && result.Value==UtilityEnum.Resolution.For)
        //    {
        //        profit = new Profit( amount :bet.Amount * (bet.Price - 1m) );

        //    }
        //    if (bet.Side == TradeSide.Lay && result.Value == UtilityEnum.Resolution.For)
        //    {
        //        profit = new Profit(amount: - bet.Amount * (bet.Price - 1m) );

        //    }
        //    if (bet.Side == TradeSide.Back && result.Value == UtilityEnum.Resolution.Against)
        //    {
        //        profit = new Profit(amount :- bet.Amount  );

        //    }
        //    if (bet.Side == TradeSide.Lay && result.Value == UtilityEnum.Resolution.For)
        //    {

        //        profit = new Profit(amount : bet.Amount );
        //    }

        //    foreach (var observer in observers)
        //    {
        //        observer.OnNext(profit);
        //    }


        //    //var single = Predictions.Where(_ => _.ParentKey == price.ParentKey).LastOrDefault();

        //    //var rec = new Bet { Date = price.Time, Key = price.Key, ParentKey = price.ParentKey, Side = price.Value.Side, Value = GetValue(price, single) };

        //    //foreach (var observer in observers)
        //    //{
        //    //    observer.OnNext(rec);
        //    //}
        //}


        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe(IObserver<Profit> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber<Profit>(observers, observer);
        }


        //public void OnNext(Result result)
        //{
        //    Results.Add(result);
        //    var single = (Predictions.Where(_ => _.ParentKey == result.ParentKey).ToArray());
        //    if (single.Length == 3)
        //    {
        //        foreach (var s in single)
        //        {
        //            double profit = 0;
        //            if (s.Value > 0)
        //            {
        //                profit = result.Value * s.Value;
        //            }
        //            Profits.Add(new DAL.Profit { Amount = profit, Date = result.Date, Target = result.Team, ParentKey = s.ParentKey });
        //        }
        //    }
        //}


    }

    //public class ProfitTrackerFactory
    //{
    //    public static ProfitTracker BuildDefault()
    //    {
    //        return new ProfitTracker(new List<Prediction>(), new List<Result>(), new List<Profit>());
    //    }


    //}



}


