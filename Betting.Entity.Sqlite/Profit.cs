using Betting.Abstract;
using Betting.Abstract.DAL;
using SQLite;
using System;
using System.Collections.Generic;

namespace Betting.Entity.Sqlite
{
    public class Profit : DBEntity, IProfit, IEquatable<Profit>
    {
        public const int Factor = 100;
        public Profit() { }

        public Profit(Guid marketId, DateTime eventDate, int amount, Guid selectionId, int wager, uint price, Guid betId)
        {
            MarketId = marketId;
            EventDate = eventDate;
            Amount = amount;
            SelectionId = selectionId;
            Wager = wager;
            Price = price;
            BetId = betId;
            Guid = Guid.NewGuid();
        }

        public Guid MarketId { get; set; }

        [Indexed]
        public Guid SelectionId { get; set; }

        [Indexed]
        public Guid BetId { get; set; }

        //public string Key { get; set; }

        /// <summary>
        /// N.B This can also be the settled date
        /// </summary>
        public DateTime EventDate { get; set; }

        public int Amount { get; set; }

        public int Wager { get; set; }

        public uint Price { get; set; }
   

        public override bool Equals(object obj)
        {
            return Equals(obj as Profit);
        }

        public bool Equals(Profit other)
        {
            return other != null &&
                   MarketId == other.MarketId &&
                   EventDate == other.EventDate &&
                   Amount == other.Amount &&
                   SelectionId == other.SelectionId &&
                   Wager == other.Wager &&
                   Price == other.Price &&
                   BetId.Equals(other.BetId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(MarketId, EventDate, Amount, SelectionId, Wager, Price, BetId);
        }

        public static bool operator ==(Profit left, Profit right)
        {
            return EqualityComparer<Profit>.Default.Equals(left, right);
        }

        public static bool operator !=(Profit left, Profit right)
        {
            return !(left == right);
        }
    }
}