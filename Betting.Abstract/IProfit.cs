using System;

namespace Betting.Abstract
{
    public interface IProfit
    {
        long Amount { get; }

        Guid BetId { get; }

        DateTime EventDate { get; }

        string MarketId { get; }

        uint Price { get;  }

        long SelectionId { get; }

        int Wager { get; }
        string Key { get; }

        // IProfit Build(long amount, Guid betId, DateTime eventDate, string marketId,int price, long selectionId,int wager);
    }
}