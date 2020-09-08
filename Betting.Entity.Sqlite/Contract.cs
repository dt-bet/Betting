using SQLite;
using System.Collections.Generic;
using Betting.Enum;
using Betting.Abstract.DAL;
using Betting.Abstract;
using System;

namespace Betting.Entity.Sqlite
{
    [Dapper.Contrib.Extensions.Table("Contract")]

    public class Contract : DBEntity, IContract
    {

        public Contract(ContractType type, List<IPrice>? prices = null) : this(type, prices, Guid.NewGuid())
        {
        }

        public Contract(Guid guid, ContractType key, List<IPrice>? prices = null) :this(key, prices, guid)
        {
        }

        private Contract(ContractType key, List<IPrice>? prices, Guid guid) : base(guid)
        {
            Type = key;
            Prices = prices;
        }

        public Contract()
        {
        }

        public ContractType Type { get; set; }

        [Ignore]
        public IReadOnlyCollection<IPrice> Prices { get; set; }

    }
}
