using SQLite;
//using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using Betting.Enum;

//using UtilityDAL;
//using UtilityDAL.Model;

namespace Betting.Entity.Sqlite
{
    public class Contract : /*DbChildRow*/IEquatable<Contract>, UtilityInterface.NonGeneric.Database.IId
    {
        public Contract()
        {
        }

        [PrimaryKey]
        public long Id { get; set; }

        public Guid Guid { get; set; }


        public ContractType Type { get; set; }

        //public long Condition { get; set; }

        //[OneToMany(CascadeOperations = CascadeOperation.All)]
        [Ignore]
        public IReadOnlyCollection<Price> Prices { get; set; }

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
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object contract) => this.Equals(contract as Contract);



        #endregion IEquatable

    }

  
}
