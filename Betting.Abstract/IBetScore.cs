using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Abstract
{
    public interface IBetScore : UtilityInterface.NonGeneric.Database.IGuid
    {
        Guid StrategyId { get;  }

        int AvgAmtOverWager { get; }

        int Count { get; }

        DateTime Date { get; }

        int AvgWager { get; }

        double Summarise();
    }
}
