using Betting.Abstract;
using SQLite;
using System;
using System.Collections.Generic;
using Betting.Enum;
using Betting.Abstract.DAL;

namespace Betting.Entity.Sqlite
{
    public class Bet : DBEntity, IBet, IEquatable<Bet>
    {
        public Bet(Guid marketId, ThreeWayBetType type, uint price, int amount, Guid selectionId, DateTime eventDate, DateTime date, Guid strategyId, TradeSide TradeSide = TradeSide.Back) : this
            (marketId, price, amount, selectionId, eventDate, date, strategyId, TradeSide)
        {
            this.Type = type;
        }

        public Bet(Guid marketId, uint price, int amount, Guid selectionId, DateTime eventDate, DateTime date, Guid strategyId, TradeSide TradeSide = TradeSide.Back)
            : this(marketId, default, TradeSide, price, amount, selectionId, eventDate, date, Guid.NewGuid(), strategyId)
        {
        }

        public Bet(Guid marketId, ThreeWayBetType type, TradeSide tradeSide, uint price, int amount, Guid selectionId, DateTime eventDate, DateTime date, Guid guid, Guid strategyId)
        {
            Guid = guid;
            StrategyId = strategyId;
            MarketId = marketId;
            Type = type;
            TradeSide = tradeSide;
            Price = price;
            Amount = amount;
            SelectionId = selectionId;
            EventDate = eventDate;
            PlacedDate = date;
            Guid = guid;

        }

#warning for sqlite use only
        public Bet()
        {
        }

        public Guid SelectionId { get; set; }

        public Guid StrategyId { get; set; }

        public DateTime PlacedDate { get; set; }

        public ThreeWayBetType Type { get; set; }

        public TradeSide TradeSide { get; }

        public Guid MarketId { get; set; }

        public uint Price { get; set; }

        public int Amount { get; set; }

        public DateTime EventDate { get; set; }

        public override string ToString()
        {
            return "EventDate " + EventDate.ToString("g") + " Price " + Price + " Amount " + Amount;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Bet);
        }

        public bool Equals(Bet other)
        {
            return other != null &&
                   PlacedDate == other.PlacedDate &&
                   Type == other.Type &&
                   MarketId == other.MarketId &&
                   Price == other.Price &&
                   Amount == other.Amount &&
                   SelectionId == other.SelectionId &&
                   EventDate == other.EventDate;
            //Key == other.Key;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(PlacedDate);
            hash.Add(Type);
            hash.Add(MarketId);
            hash.Add(Price);
            hash.Add(Amount);
            hash.Add(SelectionId);
            hash.Add(EventDate);
            //hash.Add(Key);
            return hash.ToHashCode();
        }

        public static bool operator ==(Bet left, Bet right)
        {
            return EqualityComparer<Bet>.Default.Equals(left, right);
        }

        public static bool operator !=(Bet left, Bet right)
        {
            return !(left == right);
        }
    }

    public static class BetfairBetExtension
    {
        public static Bet WithAmount(this IBet bet, int amount)
        {
            return new Bet(bet.MarketId, bet.Type, bet.Price, amount, bet.SelectionId, bet.EventDate, bet.PlacedDate, bet.Guid);
        }
    }
}