using Betting.Abstract;
using SQLite;
using System;
using Betting.Enum;

namespace Betting.Entity.Sqlite
{

    public class Price : Abstract.DAL.DBEntity, IPrice
    {
        #warning This constructor is for sqlite
        public Price()
        {
        }

        public Price(Guid selectionId, string selectionName, Guid marketId, Guid oddId, uint value, PriceSide priceSide)
        {
            SelectionId = selectionId;
            SelectionName = selectionName;
            MarketId = marketId;
            OddId = oddId;
            //Name = name;
            Value = value;
            this.Side = priceSide;
        }


        [Indexed]
        public Guid SelectionId { get; set; }

        //public string Name { get; set; }
        public string SelectionName { get; set; }

        [Indexed]
        public Guid MarketId { get; set; }

        [Indexed]
        public Guid OddId { get; set; }

        public uint Value { get; set; }

        public PriceSide Side { get; set; }
    }

    public static class PriceHelper
    {
        public static Price WithValue(this IPrice price, uint value)
        {
            return new Price(price.SelectionId, price.SelectionName, price.MarketId, price.OddId, value, price.Side);

        }
    }
}