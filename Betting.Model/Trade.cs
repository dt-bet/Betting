using NodaMoney;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityEnum.Betting;

namespace Betting.Model
{
    public  class Trade
    {
        public string Key { get; set; }
        public DateTime Date { get; set; }
        public Money Amount { get; set; }
        public Money Price { get; set; }
    }


    public static class TradeEx
    {

        public static InvestmentType ToTransaction(this Money trade)
        {
            return trade.Amount > 0 ? InvestmentType.Buy:InvestmentType.Sell;
        }

    }
}
