using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Abstract.Service
{
    public interface IGroupResult
    {
        public string Key { get; }
        public IProfit[] Profits { get; }
        public IOdd[] Odds { get; }
        public Exception[] Exceptions { get; }
    }
}
