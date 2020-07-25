using Betting.Abstract;
using SQLite;
using System;
using UtilityEnum;
using Betting.Enum;
using Betting.Abstract.DAL;

namespace Betting.Entity.Sqlite
{
    public class Order : DBEntity, IOrder
    {
        public Order()
        {
        }

        public Order(Guid betId,
            Guid marketId,
            Guid selectionId,
            int price,
            int size,
            TradeSide side,
            YesNo isComplete,
            DateTime placedDate,
            DateTime matchedDate,
            int averagePriceMatched,
            int sizeMatched)
        {
            BetId = betId;
            MarketId = marketId;
            SelectionId = selectionId;
            Price = price;
            Size = size;
            Side = side;
            IsComplete = isComplete;
            PlacedDate = placedDate;
            MatchedDate = matchedDate;
            AveragePriceMatched = averagePriceMatched;
            SizeMatched = sizeMatched;
            Guid = Guid.NewGuid();
        }

        [Indexed]
        public Guid BetId { get; set; }

        [Indexed]
        public Guid MarketId { get; set; }

        [Indexed]
        public Guid SelectionId { get; set; }

        public int Price { get; set; }

        public int Size { get; set; }

        public int SizeMatched { get; set; }

        public TradeSide Side { get; set; }

        public YesNo IsComplete { get; set; }

        public DateTime PlacedDate { get; set; }

        public DateTime MatchedDate { get; set; }

        public int AveragePriceMatched { get; set; }



        //public double Handicap { get; set; }

        //public OrderStatus Status { get; set; }
        //public PriceSize PriceSize { get; set; }

        //public double BspLiability { get; set; }

        //public PersistenceType PersistenceType { get; set; }


        //public OrderType OrderType { get; set; }
        //public double SizeRemaining { get; set; }

        //public double SizeLapsed { get; set; }

        //public double SizeCancelled { get; set; }

        //public double SizeVoided { get; set; }

        //public string RegulatorAuthCode { get; set; }

        //public string RegulatorCode { get; set; }
    }
}
