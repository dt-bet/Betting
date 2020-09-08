using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Abstract
{
    public interface IGroupService
    {

        IAsyncEnumerable<(string key, IProfit[] profits, IOdd[] odds)> Group();
    }
}
