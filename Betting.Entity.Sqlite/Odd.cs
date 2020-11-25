using Betting.Abstract;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Betting.Entity.Sqlite
{
    [Dapper.Contrib.Extensions.Table("Odd")]
    public class Odd : DBEntity, IOdd
    {
        public Odd(Guid guid, DateTime eventDate, Guid competitionId, Guid marketId, DateTime oddsDate) :
            this(eventDate, competitionId, marketId, oddsDate, guid)
        {
        }

        public Odd(DateTime eventDate, Guid competitionId, Guid marketId, DateTime oddsDate) :
            this(eventDate, competitionId, marketId, oddsDate, GuidHelper.Merge(marketId, GuidHelper.ToGuid(oddsDate)))
        {
        }

        private Odd(DateTime eventDate, Guid competitionId, Guid marketId, DateTime oddsDate, Guid guid) : base(guid)
        {
            EventDate = eventDate;
            CompetitionId = competitionId;
            MarketId = marketId;
            OddsDate = oddsDate;
            Guid = Guid.NewGuid();
        }

#warning This constructor is for sqlite
        public Odd()
        {
        }

        public DateTime EventDate { get; set; }

        public string Competition { get; set; }

        [Indexed]
        public Guid CompetitionId { get; set; }

        [Indexed]
        public Guid MarketId { get; set; }

        public DateTime OddsDate { get; set; }

        [Ignore]
        public IReadOnlyCollection<IPrice> Prices { get; set; }

    }
}