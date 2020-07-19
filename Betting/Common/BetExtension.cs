using Betting.Model;
using System;
using Betting.Enum;

namespace Betting.Math
{
    public static class BetExtension
    { 
        public static decimal UnitLiability(this Bet bet)
        {
            if (bet.Side.Equals(TradeSide.Back))
                return 1;
            else if (bet.Side.Equals(TradeSide.Lay))
                return ((decimal)bet.Price - 1);
            else
                throw new Exception("TradeSide not valid");
        }



        public static decimal UnitProfit(this Bet bet)
        {
            if (bet.Side.Equals(TradeSide.Back))
                return ((decimal)bet.Price - 1);
            else if (bet.Side.Equals(TradeSide.Lay))
                return 1;
            else
                throw new Exception("TradeSide not valid");
        }


        public static NodaMoney.Money GetProfit(this Bet bet)
        {
            NodaMoney.Money c = 0;
            if (bet.Execution.Equals(UtilityEnum.Execution.Success))
            {
                if (bet.Result == UtilityEnum.Resolution.For)
                    c = bet.UnitProfit() * (1 - bet.Commission) * ((decimal)bet.Amount);
                else
                    c = bet.UnitLiability() * (-1) * ((decimal)bet.Amount);
            }

            return c;
        }
    }
}
