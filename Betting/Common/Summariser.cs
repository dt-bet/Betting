using Betting.Abstract;
using Betting.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using UtilityHelper;

namespace Betting
{
    public class Summariser
    {
        public class Summary
        {
            public object Name { get; set; }

            [Browsable(false)]
            public object Key { get; set; }

            public DateTime EventDate { get; set; }

            public object Week { get; set; }

            public object Avg_Price { get; set; }

            public object Avg_Bet { get; set; }
            public object Sum_Bets { get; set; }
            public object Avg_Profit { get; set; }
            public object Sum_Profit { get; set; }

            [Browsable(false)]
            public Lazy<dynamic[]> items { get; set; }

            [Browsable(false)]
            public dynamic[] Items => items.Value;

        }

        //public static IEnumerable<Summary> AggregateItems(IEnumerable<IBet> bets, IEnumerable<IOdd> odds, IEnumerable<IProfit> profits, GroupType groupType)
        //{
        //    return groupType == GroupType.Selection ?
        //         Helper.GroupBySelectionId(bets, odds, profits) :
        //         NewMethod(bets, odds, profits).Select(a => Helper.SummariseByPlacedDate(a));

        //    static IEnumerable<IGrouping<DateTime, dynamic>> NewMethod(IEnumerable<IBet> bets, IEnumerable<IOdd> odds, IEnumerable<IProfit> profits)

        //        => Helper.GroupBySelectionIdAndPlacedDate(bets, odds, profits)
        //            .SelectMany(a => a)
        //            .GroupBy(g => ((DateTime)g.PlacedDate).Date);
        //}

        public static IEnumerable<Summary> AggregateItems(IEnumerable<IBet> bets, IEnumerable<IOdd> odds, IEnumerable<IProfit> profits, bool groupBySelection)
        {
            return groupBySelection ?
                 Helper.GroupBySelectionId(bets, odds, profits) :
                 NewMethod(bets, odds, profits).Select(a => Helper.SummariseByPlacedDate(a));

            static IEnumerable<IGrouping<DateTime, dynamic>> NewMethod(IEnumerable<IBet> bets, IEnumerable<IOdd> odds, IEnumerable<IProfit> profits)

                => Helper.GroupBySelectionIdAndPlacedDate(bets, odds, profits)
                    .SelectMany(a => a)
                    .GroupBy(g => ((DateTime)g.PlacedDate).Date);
        }

        public static (double sumWager, double sumAmount, int count) Summarise(IEnumerable<IProfit> profits)
        {
            return (
                profits.Sum(a => a.Wager),
                profits.Sum(a => a.Amount),
                profits.Count());
        }






        public static (double mean, double variance) EvaluateStatistics(IEnumerable<IProfit> profits)
        {
            var xx = MathNet.Numerics.Statistics.Statistics.MeanVariance(profits.Select(a => ((double)a.Amount) / a.Wager));
            return (xx.Item1, xx.Item2);
        }

        public static IEnumerable<KeyValuePair<string, double>> Aggregate(IEnumerable<IBet> bets)
        {
            return bets.GroupBy(a => (a.SelectionId, a.MarketId))
                .Select(a => new KeyValuePair<string, double>(
                    a.Key.ToString(),
                    a.Select(k => (double)k.Amount).Sum(b => b)));
        }


        public static IEnumerable<KeyValuePair<string, double>> Aggregate(IEnumerable<IProfit> profits)
        {
            return profits.GroupBy(a => (a.SelectionId, a.MarketId))
                .Select(a => new KeyValuePair<string, double>(
                    a.Key.ToString(),
                    a.Select(k => (double)k.Amount).Sum(b => b)));
        }




        private static class Helper
        {

            public static IEnumerable<Summary> GroupBySelectionId(IEnumerable<IBet> bets, IEnumerable<IOdd> odds, IEnumerable<IProfit> profits)
                => from x in bets.GroupBy(a => (a.SelectionId, a.MarketId))
                   join x2 in profits.GroupBy(a => (a.SelectionId, a.MarketId))
                           on x.Key equals x2.Key
                   into temp
                   join x3 in odds.SelectMany(o => o.Prices).GroupBy(a => (a.SelectionId, a.MarketId))
                        on x.Key equals x3.Key
                   let o = x3.First().SelectionName
                   select BuildSummary(x3.ToArray(), x.ToArray(), sdf(temp), o);

            private static IProfit[] sdf(IEnumerable<IGrouping<(Guid SelectionId, Guid MarketId), IProfit>> temp)
            {
                if (temp.Any())
                    return temp.SelectMany(a => a).ToArray();
                else
                    return temp.SelectMany(a => a).ToArray();
            }

            public static IEnumerable<IEnumerable<dynamic>> GroupBySelectionIdAndPlacedDate(IEnumerable<IBet> bets, IEnumerable<IOdd> odds, IEnumerable<IProfit> profits)
                => from x in bets.GroupBy(a => (a.SelectionId, a.MarketId))
                   join x2 in profits.GroupBy(a => (a.SelectionId, a.MarketId))
                   on x.Key equals x2.Key
                   into temp
                   join x3 in odds.SelectMany(o => o.Prices).GroupBy(a => (a.SelectionId, a.MarketId))
                       on x.Key equals x3.Key
                   let o = x3.First().SelectionName
                   select GroupByPlacedDate(x.ToArray(), temp.SelectMany(a => a).ToArray(), o);



            public static IEnumerable<dynamic> GroupByPlacedDate(IEnumerable<IBet> bets, IEnumerable<IProfit> profits, object key)
            {
                var xx = from grp in
                             from bet in bets
                             join profit in profits
                             on bet.Guid equals profit.BetId
                             into temp
                             let tuple = (bet, temp)
                             group tuple by tuple.bet.PlacedDate
                         let bet = grp.Single().bet
                         let price = grp.Average(a => a.bet.Price)
                         let amt = grp.Average(a => a.bet.Amount)
                         let profit = grp.SelectMany(a => a.temp).Select(a => a.Amount).DefaultIfEmpty(0).Sum()
                         select new
                         {

                             Name = bet.PlacedDate.ToString("F"),
                             PlacedDate = bet.PlacedDate,
                             Key = key + " " + bet.Guid,
                             Price = price,
                             Bet = amt,
                             Profit = profit
                         };

                return xx;
            }

            public static Summary BuildSummary(IPrice[] x3, IBet[] x, IProfit[] x2, dynamic Key)
            {
                var select = x2.Select(a => a.Amount / 100d).DefaultIfEmpty(0).ToArray();
                return new Summary
                {
                    Name = x3.First().Guid,
                    Key = Key,
                    Week = (x.GroupBy(a => (a.EventDate).Date).Single().Key).GetWeekOfYear(),
                    EventDate = x.First().EventDate,
                    Avg_Price = x.Average(a => a.Price / 100d).ToString("N"),
                    Avg_Bet = x.Average(a => a.Amount / 100d).ToString("N"),
                    Sum_Bets = x.Sum(a => a.Amount / 100d).ToString("N"),
                    Avg_Profit = select.Average().ToString("N"),
                    Sum_Profit = select.Sum().ToString("N"),
                    items = LazyEx.Create<dynamic[]>(() =>
                    {
                        var xx = JoinBetsAndProfits(Key, x, x2);
                        return ((IEnumerable<dynamic>)xx).ToArray();
                    })
                };
            }

            private static IEnumerable<dynamic> JoinBetsAndProfits(object key, IEnumerable<IBet> bets, IEnumerable<IProfit> profits)
                => from x in bets
                   join x3 in profits
                   on x.Guid equals x3.BetId
                   into temp
                   select new { x.PlacedDate, x.Price, x.Amount, Profit = temp.Select(a => a.Amount).DefaultIfEmpty(0).Sum() };

            public static Summary SummariseByPlacedDate(IEnumerable<dynamic> grouping)
            {
                return new Summary
                {
                    Name = grouping.First().Name,
                    Key = grouping.First().PlacedDate.ToString("F"),
                    EventDate = grouping.First().PlacedDate,
                    Avg_Price = grouping.Average(a => ((double)a.Price) / 100d).ToString("N"),
                    Avg_Bet = grouping.Average(a => ((double)a.Bet) / 100d).ToString("N"),
                    Sum_Bets = grouping.Sum(a => ((double)a.Bet) / 100d).ToString("N"),
                    Avg_Profit = grouping.Average(a => ((double)a.Profit) / 100d).ToString("N"),
                    Sum_Profit = grouping.Sum(a => ((double)a.Profit) / 100d).ToString("N"),
                    items = LazyEx.Create(() => grouping.Cast<dynamic>().ToArray())

                };
            }
        }

    }
}