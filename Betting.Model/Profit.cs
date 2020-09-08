using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Model
{
    //public class Profit
    //{
    //    public DateTime Date { get; set; }

    //    public NodaMoney.Money Amount { get; set; }
    //}
    public class Profit
    {
        public Profit() { }

        public Profit(Guid marketId, string key, DateTime eventDate, long amount, Guid selectionId, int wager, uint price, Guid betId, string eventName, string competitionName, string selectionName)
        {
            MarketId = marketId;
            Key = key;
            EventDate = eventDate;
            Amount = (NodaMoney.Money)(amount / 100d);
            SelectionId = selectionId;
            Wager = (NodaMoney.Money)(wager / 100d);
            Price = new UtilityStruct.Odd(UtilityStruct.ProbabilityEx.GetFromEuropeanOdd(price / 100d)); //(NodaMoney.Money)(price/100d);
            BetId = betId;
            EventName = eventName;
            CompetitionName = competitionName;
            SelectionName = selectionName;
        }


        public Guid MarketId { get;  }

        public string Key { get;  }

        /// <summary>
        /// N.B This can also be the settled date
        /// </summary>
        public DateTime EventDate { get; }
        public NodaMoney.Money Amount { get; }
        public Guid SelectionId { get; }
        public NodaMoney.Money Wager { get; }
        public UtilityStruct.Odd Price { get; }
        public Guid BetId { get; set; }
        public string SelectionName { get; }
        public string EventName { get; }
        public string CompetitionName { get; }
    }
}
