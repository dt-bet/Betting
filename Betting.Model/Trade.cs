using NodaMoney;
using System;
using System.Collections.Generic;
using System.Text;
using Betting.Enum;

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

        public static TradeSide ToTradeSide(this Money trade)
        {
            return trade.Amount > 0 ? TradeSide.Back: TradeSide.Lay;
        }
              
        public static TransactionSide ToTransactionSide(this Money trade)
        {
            return trade.Amount > 0 ? TransactionSide.Buy: TransactionSide.Sell;
        }

    }
}
