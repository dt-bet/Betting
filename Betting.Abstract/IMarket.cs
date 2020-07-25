using Betting.Abstract;
using Betting.Enum;
using System.Collections.Generic;

namespace Betting.Entity.Sqlite
{
    public interface IMarket: UtilityInterface.NonGeneric.Database.IGuid
    {
        IReadOnlyCollection<IContract> Contracts { get; set; }
        MarketType Type { get; set; }
    }
}