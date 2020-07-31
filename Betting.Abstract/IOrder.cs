using System;
using UtilityEnum;
using Betting.Enum;

namespace Betting.Abstract
{
    public interface IOrder : UtilityInterface.NonGeneric.Database.IGuid
    {
        Guid BetId { get; }

        Guid MarketId { get; }

        Guid SelectionId { get; }

        YesNo IsComplete { get; }

        DateTime MatchedDate { get; }

        DateTime PlacedDate { get; }

        uint Price { get; }

        uint AveragePriceMatched { get; }

        uint Size { get;}

        uint SizeMatched { get; }

        TradeSide Side { get; }
    }
}