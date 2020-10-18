using Betting.Abstract;
using SQLite;
using System;
using System.Collections.Generic;

namespace Betting.Entity.Sqlite
{
    [Dapper.Contrib.Extensions.Table("Prediction")]
    public class Prediction : DBEntity, IPrediction
    {
        public Prediction(Guid guid, DateTime eventDate, Guid competitionId, Guid marketId, DateTime oddsDate) :
            this(eventDate, competitionId, marketId, oddsDate, guid)
        {
        }

        public Prediction(DateTime eventDate, Guid competitionId, Guid marketId, DateTime oddsDate) :
            this(eventDate, competitionId, marketId, oddsDate, GuidHelper.Merge(marketId, GuidHelper.ToGuid(oddsDate)))
        {
        }

        private Prediction(DateTime eventDate, Guid competitionId, Guid marketId, DateTime predictionDate, Guid guid) : base(guid)
        {
            EventDate = eventDate;
            CompetitionId = competitionId;
            MarketId = marketId;
            PredictionDate = predictionDate;
            Guid = Guid.NewGuid();
        }

#warning This constructor is for sqlite
        public Prediction()
        {
        }

        public DateTime EventDate { get; set; }

        public string Competition { get; set; }

        [Indexed]
        public Guid CompetitionId { get; set; }

        [Indexed]
        public Guid MarketId { get; set; }

        public DateTime PredictionDate { get; set; }

        [Ignore]
        public IReadOnlyCollection<IEstimate> Estimates { get; set; }

    }
}