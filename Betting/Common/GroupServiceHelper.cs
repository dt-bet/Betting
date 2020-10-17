using Betting.Abstract;
using Betting.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.Service
{
    public  class GroupServiceHelper
    {

        public static IEnumerable<KeyValuePair<string, Task<Profit[]>>> SelectAll(IEnumerable<KeyValuePair<string, IGroupService>> groupServices)
        {
            return SelectData(groupServices);

            static IEnumerable<KeyValuePair<string, Task<Profit[]>>> SelectData(IEnumerable<KeyValuePair<string, IGroupService>> groupServices) =>
                //new (string key, Task<(string key, IProfit[] profits, IOdd[] odds)[]> task)[]{
                //    // Convert to array instead of leaving as asynenumerable since it processes faster possibly because iterated over twice 
                //    // the second time to get the error.
                //        ("Placed Date",  Task.Run(async ()=>await testModel.GroupByPlacedDayOfWeek().ToArrayAsync().AsTask())),
                //        ("HDA", Task.Run(async ()=> await testModel.GroupByHDA().ToArrayAsync().AsTask())),
                //        ("Event Date", Task.Run(async ()=>await testModel.GroupByEventDayOfWeek().ToArrayAsync().AsTask())) }

                groupServices.Select(ConvertToProfitsAsync);
        }


        public static KeyValuePair<string, Task<Profit[]>> ConvertToProfitsAsync(KeyValuePair<string, IGroupService> groupService)
        {
            return ConvertToProfitsAsync(groupService);

            static KeyValuePair<string, Task<Profit[]>> ConvertToProfitsAsync(KeyValuePair<string, IGroupService> a) =>
                KeyValuePair.Create(a.Key, Task.Run(async () =>
                {
                    var vb = await a.Value.Group().ToArrayAsync().AsTask();
                    return vb.SelectMany(kpo => ProfitHelper.JoinWithOdds(kpo.Profits, kpo.Odds, kpo.Key).ToArray()).ToArray();
                }));
        }

        //public static IEnumerable<string> SelectAllKey()
        //{
        //    foreach (DayOfWeek dow in Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>())
        //        foreach (DayOfWeek dow2 in Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>())
        //        {
        //            yield return dow.ToString() + "_" + dow2.ToString();
        //        }
        //    foreach (var hda in Enum.GetValues(typeof(ThreeWayBetType)).Cast<ThreeWayBetType>())
        //    {
        //        yield return hda.ToString();
        //    }
        //}




   
    }
}
