using Betting.Abstract;
using System;
using System.Collections.Generic;
using Betting.Enum;
using SQLite;
using Betting.Abstract.DAL;
using Dapper.Contrib.Extensions;

namespace Betting.Entity.Sqlite
{
    [Dapper.Contrib.Extensions.Table("Result")]
    [SQLite.Table("Result")]
    public class TwoWayResult : DBEntity, ITwoWayResult, IResult
    {
        public TwoWayResult(
            Guid guid,
            Guid marketId,
            Guid player1Id, AbsolutePosition player1Status,
            Guid player2Id, AbsolutePosition player2Status):
                     this(marketId, player1Id, player1Status, player2Id, player2Status, guid)
        {
        }

        public TwoWayResult(
     Guid marketId,
     Guid player1Id, AbsolutePosition player1Status,
     Guid player2Id, AbsolutePosition player2Status):
            this(marketId, player1Id, player1Status, player2Id, player2Status, marketId)
        {

        }

        public TwoWayResult(
     Guid marketId,
     Guid player1Id, AbsolutePosition player1Status,
     Guid player2Id, AbsolutePosition player2Status,
         Guid guid):base(guid)
        {
            Player2Id = player2Id;
            Player2Status = player2Status;
            MarketId = marketId;
            Player1Id = player1Id;
            Player1Status = player1Status;
        }
        public TwoWayResult()
        {
        }

        [Indexed]
        public Guid MarketId { get; set; }

        public Guid Player1Id { get; set; }

        public AbsolutePosition Player1Status { get; set; }

        public Guid Player2Id { get; set; }

        public AbsolutePosition Player2Status { get; set; }

        [Write(false)]
        [Ignore]
        public virtual Guid WinnerId
        {
            get
            {
                Guid? ss = (Player2Status == AbsolutePosition.Loser && Player1Status == AbsolutePosition.Winner ? (Guid?)Player2Id : null);

                Guid? winner = Player1Status == AbsolutePosition.Winner && Player2Status == AbsolutePosition.Loser ?
                    Player1Id : ss;
                return winner ?? default;
            }
        }

        //protected virtual void SetGuid(Guid guid)
        //{
        //    return MarketId;
        //}

        //public override bool Equals(object obj)
        //{
        //    return obj is TwoWayResult result &&
        //           Player1Id == result.Player1Id &&
        //           Player1Status == result.Player1Status &&
        //           Player2Id == result.Player2Id &&
        //           Player2Status == result.Player2Status &&
        //           MarketId == result.MarketId;
        //}

        //public override int GetHashCode()
        //{
        //    return HashCode.Combine(Player1Id, Player1Status, Player2Id, Player2Status, MarketId);
        //}

        //public bool Equals(TwoWayResult other)
        //{
        //    return this.Equals(other);
        //}

        //public static bool operator ==(TwoWayResult left, TwoWayResult right)
        //{
        //    return EqualityComparer<TwoWayResult>.Default.Equals(left, right);
        //}

        //public static bool operator !=(TwoWayResult left, TwoWayResult right)
        //{
        //    return !(left == right);
        //}
    }
}