using Betting.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using UtilityEnum.Betting;

namespace Betting.Entity.Sqlite
{
    public class Odd : IOdd
    {
        public Odd(DateTime eventDate, string competition, string competitionId, string marketId, DateTime oddsDate, Guid guid) :
       this(eventDate, competition, competitionId, marketId, oddsDate)
        {

            Guid = guid;
        }

        public Odd(DateTime eventDate, string competition, string competitionId, string marketId, DateTime oddsDate)
        {
            EventDate = eventDate;
            Competition = competition;
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

        public string CompetitionId { get; set; }

        public string MarketId { get; set; }

        public MarketType MarketType { get; set; }

        public DateTime OddsDate { get; set; }

        [SQLite.Ignore]
        public IReadOnlyCollection<IPrice> Prices { get; set; }

        public Guid Guid { get ; set ; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}