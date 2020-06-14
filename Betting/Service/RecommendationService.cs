using Betting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityEnum.Betting;
using UtilityStruct;

namespace Betting
{


    public class RecommendationService : IRecommendationTracker
    {
        ICollection<Prediction> Predictions;

        ICollection<Price> Prices;

        private readonly ICollection<IObserver<Recommendation>> observers = new List<IObserver<Recommendation>>();

        //Unsubscriber<Recommendation> RecommendationUnsubscriber = new Unsubscriber<Recommendation>();

        public RecommendationService(ICollection<Prediction> predictions, ICollection<Price> prices)
        {
            Predictions = predictions;
            Prices = prices;

        }


        public void OnNext(Prediction prediction)
        {
            Predictions.Add(prediction);

            var single = Prices.Where(_ => _.ParentKey == prediction.ParentKey).LastOrDefault();

            var rec = new Recommendation
            {
                Date = single.Time,
                Key = single.Key,
                ParentKey = single.ParentKey,
                Side = single.Value.Type == Odd.PriceType.Bid ? UtilityEnum.Betting.Side.Back : UtilityEnum.Betting.Side.Lay,
                Value = GetValue(single, prediction)
            };

            foreach (var observer in observers)
            {
                observer.OnNext(rec);
            }

            //var single = (Results.SingleOrDefault(_ => _.ParentKey == prediction.ParentKey));
            //if (single != null)
            //{
            //    var profit = prediction.Amount * single.Value;

            //    Profits.Add(new DAL.Profit { Amount = profit, Date = prediction.Date, Target = single.Team, ParentKey = single.ParentKey });
            //}
        }

        public void OnNext(Price price)
        {
            Prices.Add(price);

            var single = Predictions.Where(_ => _.ParentKey == price.ParentKey).LastOrDefault();
            if (single != null)
            {
                var rec = new Recommendation
                {
                    Date = price.Time,
                    Key = price.Key,
                    ParentKey = price.ParentKey,
                    Side = price.Value.Type == Odd.PriceType.Bid ? UtilityEnum.Betting.Side.Back : UtilityEnum.Betting.Side.Lay,
                    Value = GetValue(price, single)
                };

                foreach (var observer in observers)
                {
                    observer.OnNext(rec);
                }
            }
        }
        

        private static int GetValue(Price price, Prediction prediction)
        {
            int diff = (int)(100 * (prediction.Value.Decimal - price.Value.Value.Decimal));
            switch (price.Value.Type)
            {
                case (Odd.PriceType.Bid):
                    return diff * 100;
                case (Odd.PriceType.Offer):
                    return -diff * 100;
                default: return 0;
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

        public IDisposable Subscribe(IObserver<Recommendation> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber<Recommendation>(observers, observer);
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

        private class Unsubscriber<T> : IDisposable
        {
            private ICollection<IObserver<T>> _observers;
            private IObserver<T> _observer;

            public Unsubscriber(ICollection<IObserver<T>> observers, IObserver<T> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

    }

    //public class ProfitTrackerFactory
    //{
    //    public static ProfitTracker BuildDefault()
    //    {
    //        return new ProfitTracker(new List<Prediction>(), new List<Result>(), new List<Profit>());
    //    }


    //}



}


