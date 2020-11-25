using Betting.Abstract;
using Betting.Enum;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Betting.Entity.Sqlite
{
    [Dapper.Contrib.Extensions.Table("Prediction")]
    [Table("Prediction")]
    public class TwoWayPrediction : DBEntity, IPrediction, ITwoWayPrediction
    {
        const int EstimationCount = 2;
        protected const string Prediction = "Prediction";
        protected const string Id_ = "Id";
        protected const string Name = "Name";

        public TwoWayPrediction(Guid guid, DateTime eventDate, Guid competitionId, Guid marketId, Guid strategyId, uint player1Prediction, uint player2Prediction, Guid player1Id, Guid player2Id, string player1Name, string player2Name, DateTime predictionDate) :
          this(eventDate, competitionId, marketId, strategyId, player1Prediction, player2Prediction, player1Id, player2Id, player1Name, player2Name, predictionDate, guid)
        {

        }

        public TwoWayPrediction(DateTime eventDate, Guid competitionId, Guid marketId, Guid strategyId, uint player1Prediction, uint player2Prediction, Guid player1Id, Guid player2Id, string player1Name, string player2Name, DateTime predictionDate) :
                      this(eventDate, competitionId, marketId, strategyId, player1Prediction, player2Prediction, player1Id, player2Id, player1Name, player2Name, predictionDate, GuidHelper.Merge(marketId, GuidHelper.ToGuid(predictionDate)))
        {

        }

        public TwoWayPrediction(DateTime eventDate, Guid competitionId, Guid marketId, Guid strategyId, uint player1Prediction, uint player2Prediction, Guid player1Id, Guid player2Id, string player1Name, string player2Name, DateTime predictionDate, Guid guid) : base(guid)
        {
            EventDate = eventDate;
            CompetitionId = competitionId;
            MarketId = marketId;
            StrategyId = strategyId;
            Player1Prediction = player1Prediction;
            Player2Prediction = player2Prediction;
            Player1Id = player1Id;
            Player2Id = player2Id;
            Player1Name = player1Name;
            Player2Name = player2Name;
            PredictionDate = predictionDate;
            Guid = guid;
        }



        public TwoWayPrediction(IPrediction Prediction) : base(Prediction.Guid)
        {

            if (Prediction.Estimates.Count != EstimationCount)
            {
                throw new Exception($"Error creating {nameof(TwoWayPrediction)} since {nameof(Prediction)} parameter contain {Prediction.Estimates.Count}, not {EstimationCount}.");
            }

            var Estimations = Prediction.Estimates.ToArray();

            EventDate = Prediction.EventDate;
            Competition = Prediction.Competition;
            CompetitionId = Prediction.CompetitionId;
            MarketId = Prediction.MarketId;
            Player1Prediction = Estimations[0].Value;
            Player2Prediction = Estimations[1].Value;
            Player1Id = Estimations[0].SelectionId;
            Player2Id = Estimations[1].SelectionId;
            Player1Name = Estimations[0].SelectionName;
            Player2Name = Estimations[1].SelectionName;
            PredictionDate = Prediction.PredictionDate;
           
        }

        protected TwoWayPrediction(Guid guid) : base(guid)
        {
        }

#warning Do not use (for sqlite only)
        public TwoWayPrediction()
        {
        }

        public DateTime EventDate { get; set; }

        public string Competition { get; set; }
        
        [Indexed]
        public Guid CompetitionId { get; set; }

        [Indexed]
        public Guid MarketId { get; set; }

        [Indexed]
        public Guid StrategyId { get; set; }

        [Category("1")]
        [Description(Prediction)]
        public uint Player1Prediction { get; set; }

        [Category("2")]
        [Description(Prediction)]
        public uint Player2Prediction { get; set; }

        [Category("1")]
        [Description(Id_)]
        public Guid Player1Id { get; set; }

        [Category("2")]
        [Description(Id_)]
        public Guid Player2Id { get; set; }

        [Category("1")]
        [Description(Id_)]
        public string Player1Name { get; set; }

        [Category("2")]
        [Description(Name)]
        public string Player2Name { get; set; }

        public DateTime PredictionDate { get; set; }


        //public virtual IReadOnlyCollection<IEstimation> Estimations => SelectEstimations(this).ToArray();

        [Ignore]
        public virtual IReadOnlyCollection<IEstimate> Estimates =>
                  new Estimate[] {
               new Estimate(

              marketId : MarketId,

                   selectionId :Player1Id,
                     value: Player1Prediction,
                     predictionId: this.Guid,
                          PriceSide: PriceSide.Bid

               ){              SelectionName = Player1Name},


               new Estimate
               (
                    marketId : MarketId,
                   selectionId :Player2Id,
                   value:Player2Prediction,
                   predictionId: this.Guid,
                      PriceSide: PriceSide.Bid
                     ){              SelectionName = Player2Name},
               };


        public static explicit operator TwoWayPrediction(Prediction Prediction)
        {
            return new TwoWayPrediction(Prediction);
        }

        //protected static IEnumerable<IEstimation> SelectEstimations(TwoWayPrediction TwoWayPrediction)
        //=>
        //    from @group in
        //        from p in TwoWayPrediction.GetType().GetProperties()
        //        let cat = (CategoryAttribute)p.GetCustomAttributes(typeof(CategoryAttribute), true).FirstOrDefault()
        //        let desc = (DescriptionAttribute)p.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault()
        //        let yy = (p, cat?.Category, desc?.Description)
        //        where string.IsNullOrEmpty(yy.Category) == false && string.IsNullOrEmpty(yy.Description) == false
        //        group yy by cat.Category
        //    orderby int.Parse(@group.Key)
        //    select new Estimation(
        //    marketId: TwoWayPrediction.MarketId,
        //         name: (string)@group.Single(a => a.Description == Name).p.GetValue(TwoWayPrediction),
        //         selectionId: (long)@group.Single(a => a.Description == Id).p.GetValue(TwoWayPrediction),
        //           value: (uint)@group.Single(a => a.Description == Prediction).p.GetValue(TwoWayPrediction),
        //           PredictionId: TwoWayPrediction.Guid
        //     );

        protected virtual Guid GetGuid()
        {
            return GuidHelper.Merge(MarketId, PredictionDate.ToGuid());
        }


        public override string ToString()
        {
            return $"event date: {EventDate} marketId: {MarketId} Predictions date: {PredictionDate}";
        }
    }
}