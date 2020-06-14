using System;
using UtilityEnum;
using UtilityEnum.Betting;

namespace Betting.Abstract
{
    public interface ICurrentOrder
    {
        int AveragePriceMatched { get; set; }

        string BetId { get; set; }

        YesNo IsComplete { get; set; }

        string MarketId { get; set; }

        DateTime MatchedDate { get; set; }

        DateTime PlacedDate { get; set; }

        int Price { get; set; }

        long SelectionId { get; set; }

        TradeType Side { get; set; }

        int Size { get; set; }

        int SizeMatched { get; set; }
    }
}