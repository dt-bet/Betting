# nullable enable
using SQLite;
using System;
using System.Collections.Generic;
using Betting.Enum;

//using UtilityDAL.Model;

namespace Betting.Entity.Sqlite
{

    public class Market : IEquatable<Market> , UtilityInterface.NonGeneric.Database.IId
    {
        public Market(long id, MarketType key, List<Contract>? contracts =null)
        {
            Type = key;
            Id = id;
            Contracts = contracts;
        }

        public Market()
        {
        }

        [PrimaryKey]
        public long Id { get; set; }

        public Guid Guid { get; set; }

        [Indexed]
        public MarketType Type { get; set; }


        //[OneToMany(CascadeOperations = CascadeOperation.All)]
        [Ignore]
        public IReadOnlyCollection<Contract>? Contracts { get; set; }

        #region IEquatable


        public bool Equals(Market market) => true;/* this.Key == (market as Market).Key && (this as DbChildRow).Equals(market as DbChildRow);*/

        public override int GetHashCode()
        {
            var hashCode = -228512026;
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295;/* + GetHashCode(this as DbChildRow);*/
            return hashCode;
        }

        public override bool Equals(object market) => this.Equals(market as Market);


        #endregion comparison
    }


}
