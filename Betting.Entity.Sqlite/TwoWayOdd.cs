using Betting.Abstract;
using Betting.Abstract.DAL;
using Betting.Enum;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Betting.Entity.Sqlite
{
    [Table("Odd")]
    public class TwoWayOdd : DBEntity, IOdd, ITwoWayOdd
    {
        //public const int Factor = 100;
        protected const string Odd = "Odd";
        protected const string Id_ = "Id";
        protected const string Name = "Name";


        public TwoWayOdd(DateTime eventDate, Guid competitionId, Guid marketId, uint player1Odd, uint player2Odd, Guid player1Id, Guid player2Id, string player1Name, string player2Name, DateTime oddsDate)
        {
            EventDate = eventDate;
            //Competition = competition;
            CompetitionId = competitionId;
            MarketId = marketId;
            Player1Odd = player1Odd;
            Player2Odd = player2Odd;
            Player1Id = player1Id;
            Player2Id = player2Id;
            Player1Name = player1Name;
            Player2Name = player2Name;
            OddsDate = oddsDate;
            Guid = Guid.NewGuid();
        }


#warning Do not use (for sqlite only)
        public TwoWayOdd()
        {
        }

        public DateTime EventDate { get; set; }

        public string Competition { get; set; }

        [Indexed]
        public Guid CompetitionId { get; set; }


        [Indexed]
        public Guid MarketId { get; set; }

        [Category("1")]
        [Description(Odd)]
        public uint Player1Odd { get; set; }

        [Category("2")]
        [Description(Odd)]
        public uint Player2Odd { get; set; }

        [Category("1")]
        [Description(Id_)]
        public Guid Player1Id { get; set; }

        [Category("2")]
        [Description(Id_)]
        [Indexed]
        public Guid Player2Id { get; set; }

        [Category("1")]
        [Description(Id_)]
        public string Player1Name { get; set; }

        [Category("2")]
        [Description(Name)]
        public string Player2Name { get; set; }

        public DateTime OddsDate { get; set; }



        //public virtual IReadOnlyCollection<IPrice> Prices => SelectPrices(this).ToArray();

        [SQLite.Ignore]
        public virtual IReadOnlyCollection<IPrice> Prices =>
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
               };


        //protected static IEnumerable<IPrice> SelectPrices(TwoWayOdd twoWayOdd)
        //=>
        //    from @group in
        //        from p in twoWayOdd.GetType().GetProperties()
        //        let cat = (CategoryAttribute)p.GetCustomAttributes(typeof(CategoryAttribute), true).FirstOrDefault()
        //        let desc = (DescriptionAttribute)p.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault()
        //        let yy = (p, cat?.Category, desc?.Description)
        //        where string.IsNullOrEmpty(yy.Category) == false && string.IsNullOrEmpty(yy.Description) == false
        //        group yy by cat.Category
        //    orderby int.Parse(@group.Key)
        //    select new Price(
        //    marketId: twoWayOdd.MarketId,
        //         name: (string)@group.Single(a => a.Description == Name).p.GetValue(twoWayOdd),
        //         selectionId: (long)@group.Single(a => a.Description == Id).p.GetValue(twoWayOdd),
        //           value: (uint)@group.Single(a => a.Description == Odd).p.GetValue(twoWayOdd),
        //           oddId: twoWayOdd.Guid
        //     );




        public override string ToString()
        {
            return $"event date: {EventDate} marketId: {MarketId} odds date: {OddsDate}";
        }
    }
}