using System;
using UtilityEnum;
using Betting.Enum;

namespace Betting.Abstract
{
    public interface IOrder : UtilityInterface.NonGeneric.Database.IGuid
    {
        int AveragePriceMatched { get; set; }

        Guid BetId { get; set; }

        Guid MarketId { get; set; }

        Guid SelectionId { get; set; }

        YesNo IsComplete { get; set; }

        DateTime MatchedDate { get; set; }

        DateTime PlacedDate { get; set; }

        int Price { get; set; }


        TradeSide Side { get; set; }

        int Size { get; set; }

        int SizeMatched { get; set; }
    }
}