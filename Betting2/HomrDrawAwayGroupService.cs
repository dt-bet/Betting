//using Betfair.Abstract;
//using Betfair.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using Betting.Abstract;
using Betting.Enum;
using System.Collections.Generic;
using Betting.A;

namespace Betting2
{
    public class HomrDrawAwayGroupService : IGroupService
    {
        private readonly IModel model;

        public HomrDrawAwayGroupService(IModel model)
        {
            this.model = model;
        }


        public async IAsyncEnumerable<(string key, IProfit[] profits, IOdd[] odds)> Group()
        {
            foreach (var output in GroupByHDA(await model.Bets, await model.Results, await model.Odds))
                yield return output;

            static IEnumerable<(string key, IProfit[] profit, IOdd[] odds)> GroupByHDA(IEnumerable<IBet> bets, IResult[] results, IOdd[] odds)
            {
                foreach (var hda in Enum.GetValues(typeof(ThreeWayBetType)).Cast<ThreeWayBetType>())
                {
                    var bets2 = bets.Where(c => c.Type.Equals(hda)).ToArray();
                    var profits = ProfitHelper.SelectProfits(bets2, results).AsParallel().ToArray();
                    yield return (hda.ToString(), profits, odds);
                }
            }
        }
    }
}
