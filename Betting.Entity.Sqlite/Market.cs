# nullable enable
using SQLite;
using System;
using System.Collections.Generic;
using Betting.Enum;
using Betting.Abstract.DAL;
using Betting.Abstract;

namespace Betting.Entity.Sqlite
{

    public class Market : DBEntity, IMarket
    {
        public Market(MarketType key, List<IContract>? contracts = null)
        {
            Type = key;
            Contracts = contracts;
        }

        public Market()
        {
        }


        [Indexed]
        public MarketType Type { get; set; }


        //[OneToMany(CascadeOperations = CascadeOperation.All)]
        [Ignore]
        public IReadOnlyCollection<IContract>? Contracts { get; set; }

    }
}
