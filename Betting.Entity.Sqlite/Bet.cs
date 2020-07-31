using Betting.Abstract;
using SQLite;
using System;
using System.Collections.Generic;
using Betting.Enum;
using Betting.Abstract.DAL;

namespace Betting.Entity.Sqlite
{
    [Dapper.Contrib.Extensions.Table("Bet")]
    public class Bet : DBEntity, IBet, IEquatable<Bet>
    {
        public Bet(Guid guid, Guid marketId, uint price, int amount, Guid selectionId, Guid oddId, DateTime eventDate, DateTime date, Guid strategyId, TradeSide tradeSide = TradeSide.Back) : this
            (marketId, price, amount, selectionId, oddId, eventDate, date, strategyId, tradeSide, guid)
        {
        }

        public Bet(Guid marketId, uint price, int amount, Guid selectionId, Guid oddId, DateTime eventDate, DateTime date, Guid strategyId, TradeSide tradeSide = TradeSide.Back)
            : this(marketId, price, amount, selectionId, oddId, eventDate, date, strategyId, tradeSide, GuidHelper.Merge(marketId, strategyId,oddId, selectionId))
        {
        }

        private Bet(Guid marketId, uint price, int amount, Guid selectionId, Guid oddId, DateTime eventDate, DateTime date, Guid strategyId, TradeSide tradeSide, Guid guid)
        {
            Guid = guid;
            StrategyId = strategyId;
            MarketId = marketId;
            Side = tradeSide;
            Price = price;
            Amount = amount;
            SelectionId = selectionId;
            OddId = oddId;
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

        public Guid OddId { get; set; }

        public TradeSide Side { get; }

        [Indexed]
        public Guid MarketId { get; set; }

        public uint Price { get; set; }

        public int Amount { get; set; }

        public DateTime EventDate { get; set; }

        public ThreeWayBetType Type { get; set; }

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
            return new Bet(bet.Guid, bet.MarketId, bet.Price, amount, bet.SelectionId, bet.OddId, bet.EventDate, bet.PlacedDate, bet.Guid) { Type = bet.Type };
        }
    }
}