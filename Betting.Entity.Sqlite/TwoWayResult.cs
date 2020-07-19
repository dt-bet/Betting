using Betting.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using Betting.Enum;
using SQLite;

namespace Betting.Entity.Sqlite
{
    [SQLite.Table("Result")]
    public class TwoWayResult : IEquatable<TwoWayResult>, ITwoWayResult, IResult, UtilityInterface.NonGeneric.Database.IId
    {
        public TwoWayResult(Guid marketId,
            Guid player1Id, AbsolutePosition player1Status,
            Guid player2Id, AbsolutePosition player2Status)
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

        [PrimaryKey]
        public long Id { get; set; }

        public Guid Guid { get; set; }

        public Guid MarketId { get; set; }

        public Guid Player1Id { get; set; }

        public AbsolutePosition Player1Status { get; set; }

        public Guid Player2Id { get; set; }

        public AbsolutePosition Player2Status { get; set; }

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



        public override bool Equals(object obj)
        {
            return obj is TwoWayResult result &&
                   Player1Id == result.Player1Id &&
                   Player1Status == result.Player1Status &&
                   Player2Id == result.Player2Id &&
                   Player2Status == result.Player2Status &&
                   MarketId == result.MarketId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Player1Id, Player1Status, Player2Id, Player2Status, MarketId);
        }

        public bool Equals(TwoWayResult other)
        {
            return this.Equals(other);
        }

        public static bool operator ==(TwoWayResult left, TwoWayResult right)
        {
            return EqualityComparer<TwoWayResult>.Default.Equals(left, right);
        }

        public static bool operator !=(TwoWayResult left, TwoWayResult right)
        {
            return !(left == right);
        }
    }
}