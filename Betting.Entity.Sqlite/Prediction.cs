using Betting.Abstract;
using SQLite;
using System;
using System.Collections.Generic;

namespace Betting.Entity.Sqlite
{
    [Dapper.Contrib.Extensions.Table("Prediction")]
    public class Prediction : DBEntity, IPrediction
    {
        public Prediction(Guid guid, DateTime eventDate, Guid competitionId, Guid marketId, Guid strategyId, DateTime predictionDate) :
            this(eventDate, competitionId, marketId, strategyId, predictionDate, guid)
        {
        }

        public Prediction(DateTime eventDate, Guid competitionId, Guid marketId, Guid strategyId, DateTime predictionDate) :
            this(eventDate, competitionId, marketId, strategyId, predictionDate, GuidHelper.Merge(marketId, GuidHelper.ToGuid(predictionDate)))
        {
        }

        private Prediction(DateTime eventDate, Guid competitionId, Guid marketId, Guid strategyId, DateTime predictionDate, Guid guid) : base(guid)
        {
            EventDate = eventDate;
            CompetitionId = competitionId;
            MarketId = marketId;
            StrategyId = strategyId;
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

        public Guid StrategyId { get; }

        public DateTime PredictionDate { get; set; }

        [Ignore]
        public IReadOnlyCollection<IEstimate> Estimates { get; set; }

    }
}