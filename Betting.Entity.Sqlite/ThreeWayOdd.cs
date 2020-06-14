using Betting.Abstract;
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
        [Description(Id)]
        public long Player3Id { get; set; }

        [Category("3")]
        [Description(Name)]
        public string Player3Name { get; set; }

        public ThreeWayOdd(
            DateTime eventDate, string competition, string competitionId, string marketId, uint player1Odd, uint player2Odd, uint player3Odd, long player1Id, long player2Id, long player3Id, string player1Name, string player2Name,string player3Name,   DateTime oddsDate)
            : base(eventDate, competition, competitionId, marketId, player1Odd, player2Odd, player1Id, player2Id, player1Name, player2Name, oddsDate)
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
                   name : Player1Name,
                   selectionId :Player1Id,
                     value: Player1Odd,
                     oddId: this.Guid
               ),


               new Price
               (
                    marketId : MarketId,
                   name :Player2Name,
                   selectionId :Player2Id,
                   value:Player2Odd,
                   oddId: this.Guid
               ),

               new Price
               (
                     marketId : MarketId,
                   name : Player3Name,
                 selectionId :Player3Id,
                    value: Player3Odd,
                    oddId: this.Guid

               ),
        };
    }

    public static class ThreeWayOddHelper
    {
        public static ThreeWayOdd WithEventDate(this ThreeWayOdd odd, DateTime date)
        {
            return new ThreeWayOdd(
                date,
                odd.Competition,
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