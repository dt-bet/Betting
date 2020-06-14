# nullable enable
using SQLite;
using System;
using System.Collections.Generic;
using UtilityEnum.Betting;

//using UtilityDAL.Model;

namespace Betting.Entity.Sqlite
{

    public class Market : IEquatable<Market> 
    {
        public Market(long id, MarketType key, List<Contract>? contracts =null)
        {
            Key = key;
            Id = id;
            Contracts = contracts;
        }

        public Market()
        {
        }

        public long Id { get; set; }

        [Indexed]
        public MarketType Key { get; set; }


        //[OneToMany(CascadeOperations = CascadeOperation.All)]
        [Ignore]
        public List<Contract>? Contracts { get; set; }

        #region IEquatable


        public bool Equals(Market market) => true;/* this.Key == (market as Market).Key && (this as DbChildRow).Equals(market as DbChildRow);*/

        public override int GetHashCode()
        {
            var hashCode = -228512026;
            hashCode = hashCode * -1521134295 + Key.GetHashCode();
            hashCode = hashCode * -1521134295;/* + GetHashCode(this as DbChildRow);*/
            return hashCode;
        }

        public override bool Equals(object market) => this.Equals(market as Market);


        #endregion comparison
    }


}
