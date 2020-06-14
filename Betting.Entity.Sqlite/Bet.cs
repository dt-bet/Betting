using Betting.Abstract;
using System;
using UtilityEnum.Betting;

namespace Betting.Entity.Sqlite
{
    public class Bet : IBet
    {
        public Bet(string marketId, ThreeWayBetType type, uint price, int amount, long selectionId, DateTime eventDate, DateTime date) : this
            (marketId, price, amount, selectionId, eventDate, date)
        {
            this.Type = type;
        }

        public Bet(string marketId, uint price, int amount, long selectionId, DateTime eventDate, DateTime date)
            : this(marketId, default, price, amount, selectionId, eventDate, date, Guid.NewGuid())
        {
        }

        public Bet(string marketId, ThreeWayBetType type, uint price, int amount, long selectionId, DateTime eventDate, DateTime date, Guid guid)
        {
            GUID = guid;
            MarketId = marketId;
            Type = type;
            Price = price;
            Amount = amount;
            SelectionId = selectionId;
            EventDate = eventDate;
            PlacedDate = date;
        }

#warning for sqlite use only
        public Bet()
        {
        }

        [SQLite.Ignore]
        public Guid GUID { get; set; }

        public DateTime PlacedDate { get; set; }

        public ThreeWayBetType Type { get; set; }

        public string MarketId { get; set; }

        public uint Price { get; set; }

        public int Amount { get; set; }

        public long SelectionId { get; set; }

        public DateTime EventDate { get; set; }

        [SQLite.Ignore]
        public string Key => this.Key();

        public override string ToString()
        {
            return "EventDate " + EventDate.ToString("g") + " Price " + Price + " Amount " + Amount;
        }


     
    }

    public static class BetfairBetExtension
    {
        public static Bet WithAmount(this IBet bet, int amount)
        {
            return new Bet(bet.MarketId, bet.Type, bet.Price, amount, bet.SelectionId, bet.EventDate, bet.PlacedDate, bet.GUID);
        }
    }
}