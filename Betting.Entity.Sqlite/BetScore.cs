using Betting.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Betting.Entity.Sqlite
{
    [Dapper.Contrib.Extensions.Table("BetScore")]
    public class BetScore : DBEntity, IBetScore
    {


        public BetScore(Guid guid, Guid strategyId, int avgAmtOverWager, int count, DateTime date, int avgWager) : this(strategyId, avgAmtOverWager, count, date, avgWager, guid)
        {

        }

        public BetScore(Guid strategyId, int avgAmtOverWager, int count, DateTime date, int avgWager) : this(strategyId, avgAmtOverWager, count, date, avgWager, Guid.NewGuid())
        {

        }

        public BetScore(Guid strategyId, int avgAmtOverWager, int count, DateTime date, int avgWager, Guid guid) : base(guid)
        {
            StrategyId = strategyId;
            AvgAmtOverWager = avgAmtOverWager;
            Count = count;
            Date = date;
            AvgWager = avgWager;
        }


        public BetScore()
        {
        }

        [Indexed]
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
