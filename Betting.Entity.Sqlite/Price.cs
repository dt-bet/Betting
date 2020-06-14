using Betting.Abstract;
using System;
using UtilityEnum.Betting;

namespace Betting.Entity.Sqlite
{
    //public interface IProfit
    //{
    //    long Amount { get; set; }
    //    DateTime EventDate { get; set; }
    //    string MarketId { get; set; }
    //    int Price { get; set; }
    //    long SelectionId { get; set; }
    //    int Wager { get; set; }
    //}

    public class Price : IPrice
    {
        public const int Factor = 100;

#warning This constructor is for sqlite
        public Price()
        {
        }

        public Price(long selectionId, string marketId, string name, uint value, Guid oddId)
        {
            SelectionId = selectionId;
            MarketId = marketId;
            Name = name;
            Value = value;
            OddId = oddId;
        }

        public long SelectionId { get; set; }

        public string MarketId { get; set; }

        public string Name { get; set; }

        public uint Value { get; set; }

        public Guid OddId { get; set; }

        public PriceType Type { get; set; }
    }

    public static class PriceHelper
    {
        public static Price WithValue(this IPrice price, uint value)
        {
            return new Price(price.SelectionId, price.MarketId, price.Name, value, price.OddId);

        }
    }
}