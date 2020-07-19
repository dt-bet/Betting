using Betting.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Betting.A
{
    class PlacedDayOfWeekGroupService:IGroupService
    {
        private readonly IModel model;

        public PlacedDayOfWeekGroupService(IModel model)
        {
            this.model = model;
        }

        public async IAsyncEnumerable<(string key, IProfit[] profits, IOdd[] odds)> Group()
        {
            foreach (var output in GroupByPlacedDayOfWeek(await model.Bets, await model.Results, await model.Odds))
                yield return output;


            static IEnumerable<(string key, IProfit[] profit, IOdd[] odds)> GroupByPlacedDayOfWeek(IEnumerable<IBet> bets, IResult[] results, IOdd[] odds)
            {
                foreach (DayOfWeek dow in System.Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>())
                {
                    var bets2 = bets.Where(a => (a.PlacedDate).DayOfWeek == dow);
                    var profits = ProfitHelper.SelectProfits(bets2, results).AsParallel().ToArray();
                    yield return (dow.ToString(), profits, odds.Where(o => o.OddsDate.DayOfWeek == dow).ToArray());
                }
            }
        }
    }
}
