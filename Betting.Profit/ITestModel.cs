using Betting.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtilityInterface.NonGeneric;

namespace Betting.Profits
{
    public interface ITestModel : IName
    {
        //Task<(double mean, double variance)> GetStatistics();

        IEnumerable<KeyValuePair<string, Task<Profit[]>>> SelectAll();
    }
}
