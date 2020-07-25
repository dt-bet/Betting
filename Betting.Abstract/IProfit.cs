using System;

namespace Betting.Abstract
{
    public interface IProfit : UtilityInterface.NonGeneric.Database.IGuid
    {
        int Amount { get; }

        Guid BetId { get; }

        DateTime EventDate { get; }

        Guid MarketId { get; }

        uint Price { get;  }

        Guid SelectionId { get; }

        int Wager { get; }
        Guid StrategyId { get; }

        // IProfit Build(long amount, Guid betId, DateTime eventDate, string marketId,int price, long selectionId,int wager);
    }
}