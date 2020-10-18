using System;
using Betting.Enum;

namespace Betting.Abstract
{
    public interface IEstimate : UtilityInterface.NonGeneric.Database.IGuid
    {
        Guid PredictionId { get; set; }

        Guid MarketId { get; set; }

        //string Name { get; set; }

        Guid SelectionId { get; set; }

        string SelectionName { get; set; }

        uint Value { get; set; }

        PriceSide Side { get; set; }
    }
}