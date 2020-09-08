using Betting.Abstract;
using SQLite;
using System;
using Betting.Enum;
using Betting.Abstract.DAL;

namespace Betting.Entity.Sqlite
{
    [Dapper.Contrib.Extensions.Table("Result")]
    public class Result : DBEntity, IResult
    {
        public Result(Guid marketId, Guid winnerId, AbsolutePosition playerStatus) : this(marketId, marketId, winnerId, playerStatus)
        {
        }

        public Result(Guid guid, Guid marketId, Guid winnerId, AbsolutePosition playerStatus) : this( marketId, winnerId, playerStatus, guid)
        {
        }

        private Result(Guid marketId, Guid winnerId, AbsolutePosition playerStatus, Guid guid) : base(guid)
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
