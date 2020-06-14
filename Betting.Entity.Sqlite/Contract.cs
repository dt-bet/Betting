using SQLite;
//using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using UtilityEnum.Betting;

//using UtilityDAL;
//using UtilityDAL.Model;

namespace Betting.Entity.Sqlite
{
    public class Contract : /*DbChildRow*/IEquatable<Contract>
    {
        public Contract()
        {
        }


        public byte Key { get; set; }
        public long Condition { get; set; }

        //[OneToMany(CascadeOperations = CascadeOperation.All)]
        [Ignore]
        public List<Price> Prices { get; set; }

        //[OneToMany(CascadeOperations = CascadeOperation.All)]

        #region IEquatable


        public bool Equals(Contract contract)
        {
            //return   Key == contract?.Key 
            //               &&   Condition == contract?.Condition 
            //               &&   (this as DbChildRow).Equals(contract as DbChildRow);
            return true;
        }


        public override int GetHashCode()
        {
            var hashCode = 868662804;
            hashCode = hashCode * -1521134295; /*+ GetHashCode(this as DbChildRow);*/
            hashCode = hashCode * -1521134295 + Key.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object contract) => this.Equals(contract as Contract);



        #endregion IEquatable

    }

  
}
