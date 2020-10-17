using Betting.Abstract;
using Betting.Abstract.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Entity.Sqlite
{
    public class GroupResult : IGroupResult
    {
        public GroupResult()
        {
        }

        public GroupResult(IOdd[] odds, IProfit[] profits, string key, Exception[] exceptions)
        {
            Exceptions = exceptions;
            Odds = odds;
            Profits = profits;
            Key = key;
        }

        public string Key { get; }

        public IProfit[] Profits { get; }

        public IOdd[] Odds { get; }

        public Exception[] Exceptions { get; }


    }
}
