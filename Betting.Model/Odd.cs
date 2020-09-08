
//using Betting.Enum;
//using UtilityStruct;

//namespace Betting.Model
//{

//    public struct Odd
//    {

//        public Odd(PriceSide PriceSide, Probability value)
//        {
//            Type = PriceSide;
//            Value = value;
//        }
//        public Odd(Probability value)
//        {
//            Type = PriceSide.Bid;
//            Value = value;
//        }

//        public PriceSide Type { get; }

//        public Probability Value { get; }


//        // User-defined conversion from Digit to double
//        public static implicit operator double(Odd d)
//        {
//            return (d.Type == PriceSide.Offer ? -1 : 1) * (double)d.Value.EuropeanOdd;
//        }

//        // User-defined conversion from Digit to double
//        public static implicit operator decimal(Odd d)
//        {
//            return (d.Type == PriceSide.Offer ? -1 : 1) * d.Value.EuropeanOdd;
//        }
//    }


//    public static class OddExtension
//    {
//        public static bool IsOffer(this Odd odd) => odd.Type == PriceSide.Offer;

//        public static bool IsBid(this Odd odd) => odd.Type == PriceSide.Bid;

//        /// <summary>
//        /// Portion of unit bet that is gained i.e the unit bet minus original stake
//        /// </summary>
//        /// <param name="odd"></param>
//        /// <returns></returns>
//        public static decimal AdjustedPrice(this Odd odd) => odd - 1m;
//    }


//}


