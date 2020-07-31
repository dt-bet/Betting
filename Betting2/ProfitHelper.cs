using Betting.Abstract;
using Betting.Entity.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Betting.A
{
    public class ProfitHelper
    {
        public static IEnumerable<KeyValuePair<DayOfWeek, IEnumerable<IProfit>>> SelectProfitByDayOfWeek(IEnumerable<IBet> pastBets, IEnumerable<IResult> results)
        {
            foreach (var dow in System.Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>())
            {
                yield return new KeyValuePair<DayOfWeek, IEnumerable<IProfit>>(
                    dow,
                    ProfitHelper.SelectProfits(pastBets
                                                  .Where(a => (a.PlacedDate).DayOfWeek.Equals(dow)), results)
                                                  .ToArray());
            }
        }


        public static IEnumerable<KeyValuePair<string, (DateTime dt, double value)>> SelectProfitByDayOfWeek2(IEnumerable<IBet> pastBets, IEnumerable<IResult> results)
        {
            return System.Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().SelectMany(dow =>
            {
                return

                   ProfitHelper.SelectProfits(pastBets
                                                 .Where(a => a.PlacedDate.DayOfWeek.Equals(dow)), results)
                                                 .GroupBy(a => a.EventDate)
                                                 .Select(a =>
                                                 new KeyValuePair<string, (DateTime, double)>(dow.ToString(), (a.Key, (double)a.Sum(b => b.Amount))));

            });
        }

        public static IEnumerable<IProfit> SelectProfits(IEnumerable<IBet> bets, IEnumerable<IResult> results)
        {
            var now = DateTime.Now;
            var pastBets = bets;//

            IProfit[] profits = null;
            try
            {
                var xx = from profit in
                             from result in results
                             join pastBet in pastBets
                             on result.MarketId equals pastBet.MarketId
                             into tempBets
                             from bet in tempBets
                             where bet != null && result.WinnerId != default
                             select new Profit(

                                 result.MarketId,
                             bet.EventDate,
                             (int)(CalculateProfit(result, bet) / 100d),
                             bet.SelectionId,
                              bet.Amount,
                               bet.Price,
                                bet.Guid,
                                bet.StrategyId
                                )
                             {
                                 //Key = "No Key"
                             }
                         select profit;

                profits = xx.Where(a => a.Wager > 0).ToArray();
            }
            catch (Exception ex)
            {

            }

            return profits;
        }

        public static int CalculateProfit(IResult result, IBet bet)
        {
            if (bet == null || result == null)
            {
                return 0;
            }

            var success = bet.SelectionId == result.WinnerId;
            var xx = ((bet.Amount > 0) ? (bet.Amount) * ((int)(success ? bet.Price : 0) - 100) : 0);

            // Remove premium
            return (int)(xx > 0 ? xx * 0.98d : xx);
        }

    }
}
