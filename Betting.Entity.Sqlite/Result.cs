using Betting.Abstract;
using SQLite;
using System;
using Betting.Enum;

namespace Betting.Entity.Sqlite
{
    public class Result : IResult, UtilityInterface.NonGeneric.Database.IId
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

        [PrimaryKey]
        public long Id { get; set; }

        public Guid Guid { get; set; }

        public Guid MarketId { get; set; }

        public Guid WinnerId { get; set; }

        public AbsolutePosition PlayerStatus { get; set; }

    }
}
