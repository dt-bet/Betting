using Betting.Abstract;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Betting.Enum;

namespace Betting.Entity.Sqlite
{
    public class Odd : IOdd, UtilityInterface.NonGeneric.Database.IId
    {
        public Odd(DateTime eventDate, Guid competitionId, Guid marketId, DateTime oddsDate, Guid guid) :
       this(eventDate,  competitionId, marketId, oddsDate)
        {

            Guid = guid;
        }

        public Odd(DateTime eventDate, Guid competitionId, Guid marketId, DateTime oddsDate)
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

        [PrimaryKey]
        public long Id { get; set; }

        public Guid Guid { get; set; }

        public DateTime EventDate { get; set; }

        //public string Competition { get; set; }

        public Guid CompetitionId { get; set; }

        public Guid MarketId { get; set; }

        //public MarketType MarketType { get; set; }

        public DateTime OddsDate { get; set; }

        [SQLite.Ignore]
        public IReadOnlyCollection<IPrice> Prices { get; set; }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}