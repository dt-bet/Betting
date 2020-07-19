using Betting.Abstract;
using Betting.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Betting.Entity.Sqlite
{
    [SQLite.Table("Odd")]
    public class ThreeWayOdd : TwoWayOdd, IThreeWayOdd
    {
        [Category("3")]
        [Description(Odd)]
        public uint Player3Odd { get; set; }

        [Category("3")]
        [Description(Id_)]
        public Guid Player3Id { get; set; }

        [Category("3")]
        [Description(Name)]
        public string Player3Name { get; set; }

        public ThreeWayOdd(
            DateTime eventDate, Guid competitionId, Guid marketId, uint player1Odd, uint player2Odd, uint player3Odd, Guid player1Id, Guid player2Id, Guid player3Id, string player1Name, string player2Name,string player3Name,   DateTime oddsDate)
            : base(eventDate, competitionId, marketId, player1Odd, player2Odd, player1Id, player2Id, player1Name, player2Name, oddsDate)
        {
            Player3Odd = player3Odd;
            Player3Id = player3Id;
            Player3Name = player3Name;
        }

        public ThreeWayOdd()
        {

        }

        [SQLite.Ignore]
        public override IReadOnlyCollection<IPrice> Prices =>
           new Price[] {
               new Price(

              marketId : MarketId,
                   selectionName : Player1Name,
                   selectionId :Player1Id,
                     value: Player1Odd,
                     oddId: this.Guid,
                      priceSide: PriceSide.Offer
               ),


               new Price
               (
                    marketId : MarketId,
                   selectionName :Player2Name,
                   selectionId :Player2Id,
                   value:Player2Odd,
                   oddId: this.Guid,
                   priceSide: PriceSide.Offer
               ),

               new Price
               (
                     marketId : MarketId,
                     selectionName : Player3Name,
                     selectionId :Player3Id,
                    value: Player3Odd,
                    oddId: this.Guid,
                    priceSide: PriceSide.Offer

               ),
        };
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