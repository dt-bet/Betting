
//using UtilityEnum.Betting;
//using UtilityStruct;

//namespace Betting.Model
//{

//    public struct Odd
//    {

//        public Odd(PriceType priceType, Probability value)
//        {
//            Type = priceType;
//            Value = value;
//        }
//        public Odd(Probability value)
//        {
//            Type = PriceType.Bid;
//            Value = value;
//        }

//        public PriceType Type { get; }

//        public Probability Value { get; }


//        // User-defined conversion from Digit to double
//        public static implicit operator double(Odd d)
//        {
//            return (d.Type == PriceType.Offer ? -1 : 1) * (double)d.Value.EuropeanOdd;
//        }

//        // User-defined conversion from Digit to double
//        public static implicit operator decimal(Odd d)
//        {
//            return (d.Type == PriceType.Offer ? -1 : 1) * d.Value.EuropeanOdd;
//        }
//    }


//    public static class OddExtension
//    {
//        public static bool IsOffer(this Odd odd) => odd.Type == PriceType.Offer;

//        public static bool IsBid(this Odd odd) => odd.Type == PriceType.Bid;

//        /// <summary>
//        /// Portion of unit bet that is gained i.e the unit bet minus original stake
//        /// </summary>
//        /// <param name="odd"></param>
//        /// <returns></returns>
//        public static decimal AdjustedPrice(this Odd odd) => odd - 1m;
//    }


//}


