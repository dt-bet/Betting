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
    public class ThreeWayPrediction : TwoWayPrediction, IThreeWayPrediction
    {
        private const int EstimationCount = 3;

        public ThreeWayPrediction(DateTime eventDate, Guid competitionId, Guid marketId, uint player1Prediction, uint player2Prediction, uint player3Prediction, Guid player1Id, Guid player2Id, Guid player3Id, string player1Name, string player2Name, string player3Name, DateTime PredictionsDate)
        : this(GuidHelper.Merge(marketId, GuidHelper.ToGuid(PredictionsDate)), eventDate, competitionId, marketId, player1Prediction, player2Prediction, player3Prediction, player1Id, player2Id, player3Id, player1Name, player2Name, player3Name, PredictionsDate)
        {

        }

        public ThreeWayPrediction(Guid guid, DateTime eventDate, Guid competitionId, Guid marketId, uint player1Prediction, uint player2Prediction, uint player3Prediction, Guid player1Id, Guid player2Id, Guid player3Id, string player1Name, string player2Name, string player3Name, DateTime PredictionsDate)
        : base(guid, eventDate, competitionId, marketId, player1Prediction, player2Prediction, player1Id, player2Id, player1Name, player2Name, PredictionsDate)
        {
            Player3Prediction = player3Prediction;
            Player3Id = player3Id;
            Player3Name = player3Name;
        }


        public ThreeWayPrediction(IPrediction Prediction) : base(Prediction.Guid)
        {
            if (Prediction.Estimates.Count != EstimationCount)
            {
                throw new Exception($"Error creating {nameof(ThreeWayPrediction)} since {nameof(Prediction)} parameter contain {Prediction.Estimates.Count}, not {EstimationCount}.");
            }

            var Estimations = Prediction.Estimates.ToArray();
            Competition = Prediction.Competition;
            EventDate = Prediction.EventDate;
            CompetitionId = Prediction.CompetitionId;
            MarketId = Prediction.MarketId;
            Player1Prediction = Estimations[0].Value;
            Player2Prediction = Estimations[1].Value;
            Player3Prediction = Estimations[2].Value;
            Player1Id = Estimations[0].SelectionId;
            Player2Id = Estimations[1].SelectionId;
            Player3Id = Estimations[2].SelectionId;
            Player1Name = Estimations[0].SelectionName;
            Player2Name = Estimations[1].SelectionName;
            Player3Name = Estimations[2].SelectionName;
            PredictionDate = Prediction.PredictionDate;
        }


        public ThreeWayPrediction()
        {

        }


        [Category("3")]
        [Description(Prediction)]
        public uint Player3Prediction { get; set; }

        [Category("3")]
        [Description(Id_)]
        public Guid Player3Id { get; set; }

        [Category("3")]
        [Description(Name)]
        public string Player3Name { get; set; }



        [Ignore]
        public override IReadOnlyCollection<IEstimate> Estimates =>
           new Estimate[] {
               new Estimate(

              marketId : MarketId,

                   selectionId :Player1Id,
                     value: Player1Prediction,
                     predictionId: this.Guid,
                      PriceSide: PriceSide.Bid
               ){ SelectionName =Player1Name},


               new Estimate
               (
                    marketId : MarketId,

                   selectionId :Player2Id,
                   value:Player2Prediction,
                   predictionId: this.Guid,
                   PriceSide: PriceSide.Bid
               ){  SelectionName =Player2Name},

               new Estimate
               (
                     marketId : MarketId,
                     selectionId :Player3Id,
                    value: Player3Prediction,
                    predictionId: this.Guid,
                    PriceSide: PriceSide.Bid
               ){  SelectionName =Player3Name},
        };

        public static explicit operator ThreeWayPrediction(Prediction Prediction)
        {
            return new ThreeWayPrediction(Prediction);
        }
    }

    public static class ThreeWayPredictionHelper
    {
        public static ThreeWayPrediction WithEventDate(this ThreeWayPrediction Prediction, DateTime date)
        {
            return new ThreeWayPrediction(
                date,
                Prediction.CompetitionId,
                Prediction.MarketId,
                Prediction.Player1Prediction,
                Prediction.Player2Prediction,
                Prediction.Player3Prediction,
                Prediction.Player1Id,
                Prediction.Player2Id,
                Prediction.Player3Id,
                Prediction.Player1Name,
                Prediction.Player2Name,
                Prediction.Player3Name,
                Prediction.PredictionDate)
            {
                Competition = Prediction.Competition
            };
        }
    }
}