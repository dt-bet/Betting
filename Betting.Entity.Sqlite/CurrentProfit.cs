using Betting.Abstract;
using System;

namespace Betting.Entity.Sqlite
{

    public class CurrentProfit : ICurrentProfit
    {
        public const int Factor = 100;

        public CurrentProfit(string marketId, long selectionId, int amount)
        {
            MarketId = marketId;
            SelectionId = selectionId;
            this.Amount = amount;
        }

        public CurrentProfit() { }

        public string MarketId { get; set; }

        public long Amount { get; set; }

        public long SelectionId { get; set; }
    }
}