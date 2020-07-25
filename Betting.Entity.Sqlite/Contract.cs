using SQLite;
using System.Collections.Generic;
using Betting.Enum;
using Betting.Abstract.DAL;
using Betting.Abstract;

namespace Betting.Entity.Sqlite
{
    public class Contract : DBEntity, IContract
    {
        public ContractType Type { get; set; }

        [Ignore]
        public IReadOnlyCollection<IPrice> Prices { get; set; }

    }
}
