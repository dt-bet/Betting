using System;
using Betting.Enum;

namespace Betting.Abstract
{
    public interface IBet: UtilityInterface.NonGeneric.Database.IGuid
    {

        Guid MarketId { get; }

        Guid SelectionId { get; }

        Guid StrategyId { get; set; }

        int Amount { get; }

        DateTime EventDate { get; }

        DateTime PlacedDate { get; set; }

        uint Price { get; }

        ThreeWayBetType Type { get; }

    }
}
