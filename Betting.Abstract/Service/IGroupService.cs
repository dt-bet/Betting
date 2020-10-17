using Betting.Abstract.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Abstract
{
    public interface IGroupService
    {

        IAsyncEnumerable<IGroupResult> Group();
    }
}
