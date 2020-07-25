using Betting.Abstract;
using Betting.Abstract.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Entity.Sqlite
{
    public class BetScore : DBEntity, IBetScore
    {
        public Guid StrategyId { get; set; }

        public int AvgAmtOverWager { get; set; }

        public int Count { get; set; }

        public DateTime Date { get; set; }

        public int AvgWager { get; set; }

        public double Summarise()
        {
            throw new NotImplementedException();
        }
    }
}
