using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Betting.Abstract
{
    public interface IOdd : UtilityInterface.NonGeneric.Database.IGuid
    {
        Guid MarketId { get; }

        DateTime EventDate { get; }

        string Competition { get; }

        Guid CompetitionId { get; }

        DateTime OddsDate { get; }

        IReadOnlyCollection<IPrice> Prices { get;  }

        Percent Margin => (Prices.Sum(a => 100d / a.Value) - 100) / 100;
    }
}
