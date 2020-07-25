using Betting.Abstract;
using SQLite;
using System;
using Betting.Enum;
using Betting.Abstract.DAL;

namespace Betting.Entity.Sqlite
{
    public class Result : DBEntity, IResult
    {
        public Result(Guid marketId, Guid winnerId, AbsolutePosition playerStatus)
        {
            MarketId = marketId;
            WinnerId = winnerId;
            PlayerStatus = playerStatus;
        }

        public Result()
        {
        }

        [Indexed]
        public Guid MarketId { get; set; }

        [Indexed]
        public Guid WinnerId { get; set; }

        public AbsolutePosition PlayerStatus { get; set; }

    }
}
