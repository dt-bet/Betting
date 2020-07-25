using Betting.Enum;
using System.Collections.Generic;

namespace Betting.Abstract
{
    public interface IContract : UtilityInterface.NonGeneric.Database.IGuid
    {
        IReadOnlyCollection<IPrice> Prices { get; set; }
        ContractType Type { get; set; }
    }
}