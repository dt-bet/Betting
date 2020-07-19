
using System;
using System.Collections.Generic;
using System.Linq;
using Betting.Abstract;
using Betting.Model;
using NodaTime;

namespace Betting
{

    public static partial class ProfitHelper
    {

        public static IEnumerable<(DateTime, IEnumerable<Profit>)> GroupProfitByMonth(this IEnumerable<Profit> profit)
        {
            return GroupProfitByTimeRange(profit, a => new DateTime(a.EventDate.Year, a.EventDate.Month, 1));
        }
        public static IEnumerable<(DateTime, IEnumerable<Profit>)> GroupProfitByWeek(this IEnumerable<Profit> profit)
        {
            return GroupProfitByTimeRange(profit, a => new LocalDate(a.EventDate.Year, a.EventDate.Month, a.EventDate.Day).Previous(IsoDayOfWeek.Monday).ToDateTimeUnspecified());
        }

        public static IEnumerable<(DateTime, IEnumerable<Profit>)> GroupProfitByDay(this IEnumerable<Profit> profit)
        {
            return GroupProfitByTimeRange(profit, a => a.EventDate.Date);
        }


        static IEnumerable<(DateTime, IEnumerable<Profit>)> GroupProfitByTimeRange(this IEnumerable<Profit> profit, Func<Profit, DateTime> keySelector)
        {
            return profit
                 .GroupBy(keySelector)
                 .Select(a => Standard(a));

            static (DateTime, IEnumerable<Profit>) Standard(IGrouping<DateTime, Profit> a)
            {
                return (a.Key, a.ToArray().AsEnumerable())/* (double)a.Select(a=>a.Amount).Sum(NodaMoney.Money.ToDecimal))*/;
            }

        }





        public static IEnumerable<Profit> JoinWithOdds(IEnumerable<IProfit> profits, IEnumerable<IOdd> odds, string key = "Key is Null")

        => from profit in profits
           join odd in odds
           on profit.MarketId equals odd.MarketId
           into tempOdds
           from odd_price in tempOdds.SelectMany(o => o.Prices.Where(a => a.SelectionId == profit.SelectionId && profit.Price == a.Value).Select(p => (o, p))).Take(1)
           //let comp = odd_price.o.Competition
           //let names = odd_price.o.Prices.Select(a => a.Name)
           //let combinedName = string.Join(',', names)
           //let selectionName = odd_price.p.Name
           select new Profit(profit.MarketId, key, profit.EventDate, profit.Amount, profit.SelectionId, profit.Wager, profit.Price, profit.BetId,"","","");




        //public async Task<(double mean, double variance)> GetStatistics(IModel model)
        //{
        //    var bets = (await model.Bets);

        //    var pts = ProfitHelper.SelectProfits(bets, (await model.Results)).AsParallel().ToArray();

        //    var xx = Summariser.EvaluateStatistics(pts);

        //    return xx;
        //}
    }


}