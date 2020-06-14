using Betting.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilityEnum.Betting;

namespace Betting.Entity.Sqlite
{
    public class Result : IEquatable<Result>, IResult
    {
        public Result(string marketId, long winnerId, AbsolutePosition playerStatus)
        {
            MarketId = marketId;
            WinnerId = winnerId;
            PlayerStatus = playerStatus;
        }

        public Result()
        {
        }

        public string MarketId { get; set; }

        public long WinnerId { get; set; }

        public AbsolutePosition PlayerStatus { get; set; }

        public bool Equals(Result other)
        {
            return other.MarketId == MarketId && other.WinnerId == WinnerId;
        }

        public override int GetHashCode()
        {
            return MarketId.Select(c => (int)c).Aggregate((a, b) => a * b);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Result);
        }
    }
}
