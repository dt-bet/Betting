using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Abstract
{
    public interface IResult : UtilityInterface.NonGeneric.Database.IGuid
    {
        Guid Guid { get; set; }

        Guid MarketId { get; }

        Guid WinnerId { get; }
    }
}
