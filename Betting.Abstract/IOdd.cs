using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Abstract
{
    public interface IOdd
    {
        Guid Guid { get; }

        string MarketId { get; }

        DateTime EventDate { get; }

        string Competition { get; }

        string CompetitionId { get; }

        DateTime OddsDate { get; }

        IReadOnlyCollection<IPrice> Prices { get;  }

    }
}
