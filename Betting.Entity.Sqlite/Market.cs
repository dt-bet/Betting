# nullable enable
using SQLite;
using System;
using System.Collections.Generic;
using Betting.Enum;
using Betting.Abstract.DAL;
using Betting.Abstract;

namespace Betting.Entity.Sqlite
{
    [Dapper.Contrib.Extensions.Table("Market")]

    public class Market : DBEntity, IMarket
    {
        public Market(MarketType type, List<IContract>? contracts = null):this(type, contracts, Guid.NewGuid())
        {
        }

        public Market(Guid guid, MarketType key, List<IContract>? contracts = null):this(key, contracts, guid)
        {
        }

        private Market( MarketType key, List<IContract>? contracts, Guid guid) : base(guid)
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
