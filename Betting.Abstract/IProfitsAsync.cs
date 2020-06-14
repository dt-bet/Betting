using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Betting.Abstract
{
    public interface IProfitsAsync
    {
        Task<IProfit[]> Profits { get; }

    }
}
