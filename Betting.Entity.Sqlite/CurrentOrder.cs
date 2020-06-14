using Betting.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityEnum;
using UtilityEnum.Betting;

namespace Betting.Entity.Sqlite
{
    public class CurrentOrder : ICurrentOrder
    {
        public const short Factor = 100;

        public CurrentOrder()
        {
        }

        public CurrentOrder(string betId,
            string marketId,
            long selectionId,
            int price,
            int size,
            TradeType side,
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
        }

        public string BetId { get; set; }


        public string MarketId { get; set; }


        public long SelectionId { get; set; }


        //public double Handicap { get; set; }


        //public PriceSize PriceSize { get; set; }
        public int Price { get; set; }

        public int Size { get; set; }

        //public double BspLiability { get; set; }


        public TradeType Side { get; set; }


        //public OrderStatus Status { get; set; }
        public YesNo IsComplete { get; set; }

        //public PersistenceType PersistenceType { get; set; }


        //public OrderType OrderType { get; set; }


        public DateTime PlacedDate { get; set; }

        public DateTime MatchedDate { get; set; }

        public int AveragePriceMatched { get; set; }

        public int SizeMatched { get; set; }

        //public double SizeRemaining { get; set; }

        //public double SizeLapsed { get; set; }

        //public double SizeCancelled { get; set; }

        //public double SizeVoided { get; set; }

        //public string RegulatorAuthCode { get; set; }

        //public string RegulatorCode { get; set; }
    }
}
