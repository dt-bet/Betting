using Betting.Abstract;
using System;

namespace Betting.Entity.Sqlite
{
    public class Profit : IProfit
    {
        public const int Factor = 100;
        public Profit() { }

        public Profit(string marketId, DateTime eventDate, long amount, long selectionId, int wager, uint price, Guid betId)
        {
            MarketId = marketId;
            EventDate = eventDate;
            Amount = amount;
            SelectionId = selectionId;
            Wager = wager;
            Price = price;
            BetId = betId;
        }

        public string MarketId { get; set; }

        public string Key { get; set; }

        /// <summary>
        /// N.B This can also be the settled date
        /// </summary>
        public DateTime EventDate { get; set; }
        public long Amount { get; set; }
        public long SelectionId { get; set; }
        public int Wager { get; set; }
        public uint Price { get; set; }
        public Guid BetId { get ; set ; }


    }
}