
using System;
using UtilityStruct;

namespace Betting.Model
{




    public  class Bet //: ITrade
    {

        //[Display(Name = "Placed Date")]
        //[DataType(DataType.Date)]
        //[NotNull]
        public DateTime Placed { get; set; }

        public UtilityEnum.Resolution Result { get; set; }

        //[NotNull]
        public  UtilityEnum.Execution Execution { get; set; }

        //[NotNull]
        public Enum.TradeSide Side { get; set; }


        public NodaMoney.Money Commission { get; set; } = 0;

        //[Range(1, 100000)]
        public Probability Price { get; set; }
  

        public NodaMoney.Money Amount { get; set; }


        public NodaMoney.Money Profit { get; set; }


        public NodaMoney.Money Total { get; set; }


        //public TimeSpan TimeDiff { get; set; }
      
        public string ContractName { get; set; }

    }


    public static class BetEx
    {
        public static bool IsBack(this Bet bet) => bet.Side == Enum.TradeSide.Back;

        public static bool IsLay(this Bet bet) => bet.Side == Enum.TradeSide.Lay;

    }




    //public class Bet
    //{


    ////[PrimaryKey, AutoIncrement]
    //public Int64 Id { get; set; }

    ////[NotNull]
    //public long ContractId { get; set; }

    //[NotNull]
    //public string ContractType { get; set; }



    //}



    //public partial class Bet
    //{

    //    //[Ignore]
    //    public TradeSide Side
    //    {
    //        get { return (TradeSide)Enum.Parse(typeof(TradeSide), Side, true); }
    //        set { Side = Enum.GetName(typeof(TradeSide), value); }
    //    }





    //    //[Ignore]
    //    public DateTime PlacedAsDateTime
    //    {

    //        get
    //        {
    //            if (Placed == null)
    //                return default(DateTime);
    //            else
    //            return DateTime.Parse(Placed);
    //        }
    //        set
    //        {
    //            Placed = value.ToString("yyyy-MM-ddTHH:mm:ss");
    //        }
    //    }






    //    //[Ignore]
    //    public byte SideAsByteId
    //    {
    //        get
    //        {
    //            return (byte)Side;
    //        }
    //        set
    //        {
    //            Side = ((TradeSide)value).ToString();
    //        }
    //    }

    //    //[Ignore]
    //    public decimal PriceAsDecimal
    //    {
    //        get
    //        {
    //            return ((decimal)Price) / 100;
    //        }
    //        set
    //        {
    //            Price = (int)(value * 100);
    //        }
    //    }

    //    //[Ignore]
    //    public decimal AmountAsDecimal
    //    {
    //        get
    //        {
    //            return ((decimal)Amount) / 100;
    //        }
    //        set
    //        {
    //            Amount = (int)(value * 100);
    //        }


    //    }

    //    //[Ignore]
    //    public decimal ProfitAsDecimal
    //    {
    //        get
    //        {
    //            return ((decimal)Profit) / 100;
    //        }
    //        set
    //        {
    //            Profit = (int)(value * 100);
    //        }


    //    }


    //    //[Ignore]
    //    public UtilityEnum.Execution UtilityEnum.ExecutionAsEnum
    //    {
    //        get
    //        {
    //            return (UtilityEnum.Execution)Enum.Parse(typeof(UtilityEnum.Execution),UtilityEnum.Execution, true);
    //        }

    //        set
    //        {
    //            UtilityEnum.Execution = value.ToString();
    //        }
    //    }

    //    //[Ignore]
    //    public decimal CommissionAsDecimal
    //    {
    //        get
    //        {
    //            return (decimal)Commission / 100;
    //        }
    //        set
    //        {
    //            Commission = (int)(value * 100);
    //        }
    //    }


    //[Ignore]
    //public DateTime StartTime { get; set; }

    //[Ignore]
    //public string Name { get; set; }

    //[Ignore]
    //public decimal UnitAmount { get; set; }
    //[Ignore]
    //public decimal Risk { get; set; }

    //[Range(1, 7)]
    //[Ignore]
    //public byte Week { get; set; }

    //public string Strategy { get; set; }

    //[NotNull]
    //public string EventName { get; set; }


    //public String EventDateId
    //{

    //    get
    //    {
    //        return StartTime.ToString("yyyy-MM-ddTHH:mm:ss");
    //    }
    //    set
    //    {
    //        StartTime = DateTime.Parse(value);
    //    }
    //}



    //public byte ContractTypeId
    //{
    //    get
    //    {
    //        return (ContractType)this.ContractType;
    //    }
    //    set
    //    {
    //        ContractType = (byte)value;
    //    }
    //}






    //public int UnitAmountInt
    //{
    //    get
    //    {
    //        return (int)(UnitAmount * 100);
    //    }
    //    set
    //    {
    //        UnitAmount = (decimal)value / 100;
    //    }
    //}




    //public int RunningProfitInt
    //{
    //    get
    //    {
    //        return (int)(Total * 100);
    //    }
    //    set
    //    {
    //        Total = value / 100;
    //    }
    //}






    //[NotNull]
    //public string Url { get; set; }


    //#endregion SQLiteDataTypes
}




 

