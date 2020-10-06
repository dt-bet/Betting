using Betting.Abstract;
using Betting.Enum;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Betting.Entity.Sqlite
{
    [Dapper.Contrib.Extensions.Table("Odd")]
    [Table("Odd")]
    public class ThreeWayOdd : TwoWayOdd, IThreeWayOdd
    {
        private const int PriceCount = 3;

        public ThreeWayOdd(DateTime eventDate, Guid competitionId, Guid marketId, uint player1Odd, uint player2Odd, uint player3Odd, Guid player1Id, Guid player2Id, Guid player3Id, string player1Name, string player2Name, string player3Name, DateTime oddsDate)
        : this(GuidHelper.Merge(marketId, GuidHelper.ToGuid(oddsDate)), eventDate, competitionId, marketId, player1Odd, player2Odd, player3Odd, player1Id, player2Id, player3Id, player1Name, player2Name, player3Name, oddsDate)
        {

        }

        public ThreeWayOdd(Guid guid, DateTime eventDate, Guid competitionId, Guid marketId, uint player1Odd, uint player2Odd, uint player3Odd, Guid player1Id, Guid player2Id, Guid player3Id, string player1Name, string player2Name, string player3Name, DateTime oddsDate)
        : base(guid, eventDate, competitionId, marketId, player1Odd, player2Odd, player1Id, player2Id, player1Name, player2Name, oddsDate)
        {
            Player3Odd = player3Odd;
            Player3Id = player3Id;
            Player3Name = player3Name;
        }


        public ThreeWayOdd(IOdd odd) : base(odd.Guid)
        {
            if (odd.Prices.Count != PriceCount)
            {
                throw new Exception($"Error creating {nameof(ThreeWayOdd)} since {nameof(odd)} parameter contain {odd.Prices.Count}, not {PriceCount}.");
            }

            var prices = odd.Prices.ToArray();

            EventDate = odd.EventDate;
            CompetitionId = odd.CompetitionId;
            MarketId = odd.MarketId;
            Player1Odd = prices[0].Value;
            Player2Odd = prices[1].Value;
            Player3Odd = prices[2].Value;
            Player1Id = prices[0].SelectionId;
            Player2Id = prices[1].SelectionId;
            Player3Id = prices[2].SelectionId;
            Player1Name = prices[0].SelectionName;
            Player2Name = prices[1].SelectionName;
            Player3Name = prices[2].SelectionName;
            OddsDate = odd.OddsDate;
        }


        public ThreeWayOdd()
        {

        }


        [Category("3")]
        [Description(Odd)]
        public uint Player3Odd { get; set; }

        [Category("3")]
        [Description(Id_)]
        public Guid Player3Id { get; set; }

        [Category("3")]
        [Description(Name)]
        public string Player3Name { get; set; }



        [Ignore]
        public override IReadOnlyCollection<IPrice> Prices =>
           new Price[] {
               new Price(

              marketId : MarketId,

                   selectionId :Player1Id,
                     value: Player1Odd,
                     oddId: this.Guid,
                      priceSide: PriceSide.Bid
               ){ SelectionName =Player1Name},


               new Price
               (
                    marketId : MarketId,

                   selectionId :Player2Id,
                   value:Player2Odd,
                   oddId: this.Guid,
                   priceSide: PriceSide.Bid
               ){  SelectionName =Player2Name},

               new Price
               (
                     marketId : MarketId,
                     selectionId :Player3Id,
                    value: Player3Odd,
                    oddId: this.Guid,
                    priceSide: PriceSide.Bid
               ){  SelectionName =Player3Name},
        };

        public static explicit operator ThreeWayOdd(Odd odd)
        {
            return new ThreeWayOdd(odd);
        }
    }

    public static class ThreeWayOddHelper
    {
        public static ThreeWayOdd WithEventDate(this ThreeWayOdd odd, DateTime date)
        {
            return new ThreeWayOdd(
                date,
                odd.CompetitionId,
                odd.MarketId,
                odd.Player1Odd,
                odd.Player2Odd,
                odd.Player3Odd,
                odd.Player1Id,
                odd.Player2Id,
                odd.Player3Id,
                odd.Player1Name,
                odd.Player2Name,
                odd.Player3Name,
                odd.OddsDate);
        }
    }
}