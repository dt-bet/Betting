using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Abstract
{
    public interface IOdds
    {
        IEnumerable<IOdd> Odds { get; }
    }
}
