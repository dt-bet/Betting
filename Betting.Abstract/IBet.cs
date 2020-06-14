using Betting.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityEnum.Betting;

namespace Betting.Abstract
{
    public interface IBet
    {
        Guid GUID { get; set; }

        string MarketId { get; }

        int Amount { get; }

        DateTime EventDate { get; }

        uint Price { get; }

        long SelectionId { get; }

        ThreeWayBetType Type { get; }

        DateTime PlacedDate { get; set; }
    }

    public static class BetUtility
    {
        public static string Key(this IBet bet) => bet.MarketId + " " + bet.SelectionId;

        public static dynamic Key2(this IBet bet) => (bet.MarketId , bet.SelectionId, bet.PlacedDate);
    }
}
