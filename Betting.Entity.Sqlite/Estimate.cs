using Betting.Abstract;
using SQLite;
using System;
using Betting.Enum;

namespace Betting.Entity.Sqlite
{
    [Dapper.Contrib.Extensions.Table("Estimation")]
    public class Estimate : DBEntity, IEstimate
    {

        public Estimate(Guid selectionId,  Guid marketId, Guid predictionId, uint value, PriceSide PriceSide) :this(selectionId, marketId, predictionId, value, PriceSide, GuidHelper.Merge(selectionId, predictionId))
        {
        }

        public Estimate(Guid guid, Guid selectionId, Guid marketId, Guid predictionId, uint value, PriceSide PriceSide): this( selectionId, marketId, predictionId, value, PriceSide, guid)
        {
        }

        private Estimate(Guid selectionId, Guid marketId, Guid predictionId, uint value, PriceSide PriceSide, Guid guid) : base(guid)
        {
            SelectionId = selectionId;
            //SelectionName = selectionName;
            MarketId = marketId;
            PredictionId = predictionId;
            //Name = name;
            Value = value;
            this.Side = PriceSide;
        }

#warning This constructor is for sqlite
        public Estimate()
        {
        }



        [Indexed]
        public Guid SelectionId { get; set; }

        //public string Name { get; set; }
        public string SelectionName { get; set; }

        [Indexed]
        public Guid MarketId { get; set; }

        [Indexed]
        public Guid PredictionId { get; set; }

        public uint Value { get; set; }

        public PriceSide Side { get; set; }
    }

    public static class EstimationHelper
    {
        public static Estimate WithValue(this IEstimate Estimation, uint value)
        {
            return new Estimate(Estimation.SelectionId, Estimation.MarketId, Estimation.PredictionId, value, Estimation.Side) { SelectionName = Estimation.SelectionName };

        }
    }
}