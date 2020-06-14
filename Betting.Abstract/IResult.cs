using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Abstract
{
    public interface IResult
    {
        string MarketId { get; }

        long WinnerId { get; }
    }
}
