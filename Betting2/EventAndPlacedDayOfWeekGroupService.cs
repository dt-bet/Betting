using Betting.Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Betting.A
{
    class EventAndPlacedDayOfWeekGroupService : IGroupService
    {
        private readonly IModel model;

        public EventAndPlacedDayOfWeekGroupService(IModel model)
        {
            this.model = model;
        }

        public async IAsyncEnumerable<(string key, IProfit[] profits, IOdd[] odds)> Group()
        {
            foreach (var output in GroupByEventAndPlacedDayOfWeek(await model.Bets, await model.Results, await model.Odds))
                yield return output;

            static IEnumerable<(string key, IProfit[] profit, IOdd[] odds)> GroupByEventAndPlacedDayOfWeek(IEnumerable<IBet> bets, IResult[] results, IOdd[] odds)
            {
                foreach (DayOfWeek dow in System.Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>())
                {
                    foreach (DayOfWeek dow2 in System.Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>())
                    {
                        var bets2 = bets.Where(a => a.EventDate.DayOfWeek == dow).Where(a => a.PlacedDate.DayOfWeek == dow2).Where(a => (a.EventDate - a.PlacedDate).TotalDays <= 7 && (a.EventDate - a.PlacedDate).TotalDays > 1);
                        var odds2 = odds.Where(a => a.EventDate.DayOfWeek == dow).Where(a => a.OddsDate.DayOfWeek == dow2).Where(a => (a.EventDate - a.OddsDate).TotalDays <= 7 && (a.EventDate - a.OddsDate).TotalDays > 1);
                        if (bets2.Any())
                        {
                            var profits = ProfitHelper.SelectProfits(bets2, results).ToArray();
                            yield return (dow.ToString() + "_" + dow2.ToString(), profits, odds);
                        }
                        else
                        {

                        }
                    }
                }
            }

        }
    }
}
