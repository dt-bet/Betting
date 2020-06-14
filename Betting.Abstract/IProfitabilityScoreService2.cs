using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Betting.Abstract
{
    public interface IProfitabilityScoreService2
    {
        Task<IBetScore> GetBetScore(string source, string key, DateTime dateTime);
    }
}
