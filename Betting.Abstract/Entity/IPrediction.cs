using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Abstract
{
    public interface IPrediction : UtilityInterface.NonGeneric.Database.IGuid
    {
        Guid MarketId { get; }

        DateTime EventDate { get; }

        string Competition { get; }

        Guid CompetitionId { get; }

        DateTime PredictionDate { get; }

        IReadOnlyCollection<IEstimate> Estimates { get;  }
        Guid StrategyId { get; }
    }
}
