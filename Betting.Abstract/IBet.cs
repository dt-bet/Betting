using System;
using Betting.Enum;

namespace Betting.Abstract
{
    public interface IBet: UtilityInterface.NonGeneric.Database.IGuid
    {

        Guid MarketId { get; }

        Guid SelectionId { get; }

        Guid StrategyId { get; }

        int Amount { get; }

        DateTime EventDate { get; }

        DateTime PlacedDate { get; }

        uint Price { get; }

        ThreeWayBetType Type { get; }

        Guid OddId { get; }
    }
}
