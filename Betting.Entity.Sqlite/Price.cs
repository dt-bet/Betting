using Betting.Abstract;
using SQLite;
using System;
using Betting.Enum;

namespace Betting.Entity.Sqlite
{
    [Dapper.Contrib.Extensions.Table("Price")]
    public class Price : DBEntity, IPrice
    {

        public Price(Guid selectionId,  Guid marketId, Guid oddId, uint value, PriceSide priceSide) :this(selectionId, marketId, oddId, value, priceSide, GuidHelper.Merge(selectionId, oddId))
        {
        }

        public Price(Guid guid, Guid selectionId, Guid marketId, Guid oddId, uint value, PriceSide priceSide): this( selectionId, marketId, oddId, value, priceSide, guid)
        {
        }

        private Price(Guid selectionId, Guid marketId, Guid oddId, uint value, PriceSide priceSide, Guid guid) : base(guid)
        {
            SelectionId = selectionId;
            //SelectionName = selectionName;
            MarketId = marketId;
            OddId = oddId;
            //Name = name;
            Value = value;
            this.Side = priceSide;
        }

#warning This constructor is for sqlite
        public Price()
        {
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
            return new Price(price.SelectionId, price.MarketId, price.OddId, value, price.Side) { SelectionName = price.SelectionName };

        }
    }
}