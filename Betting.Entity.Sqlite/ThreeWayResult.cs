using Betting.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using UtilityEnum.Betting;

namespace Betting.Entity.Sqlite
{
    [SQLite.Table("Result")]
    public class ThreeWayResult : TwoWayResult, IThreeWayResult, IEquatable<ThreeWayResult>
    {
        public ThreeWayResult(string marketId,
            long player1Id, AbsolutePosition player1Status,
            long player2Id, AbsolutePosition player2Status,
            long player3Id, AbsolutePosition player3Status
            ) : base(marketId, player1Id, player1Status, player2Id, player2Status)
        {
            Player3Id = player3Id;
            Player3Status = player3Status;
        }

        public ThreeWayResult()
        {
        }

        public long Player3Id { get; set; }
        public AbsolutePosition Player3Status { get; set; }

        public override long WinnerId
        {
            get
            {
                long? ss = (Player1Status == AbsolutePosition.Winner
                            && Player2Status == AbsolutePosition.Loser
                            && Player3Status == AbsolutePosition.Loser ? (long?)Player1Id : null);

                long? ss1 = (Player1Status == AbsolutePosition.Loser
                            && Player2Status == AbsolutePosition.Winner
                            && Player3Status == AbsolutePosition.Loser ? (long?)Player2Id : null);

                long? ss2 = (Player1Status == AbsolutePosition.Loser
                            && Player2Status == AbsolutePosition.Loser
                            && Player3Status == AbsolutePosition.Winner ? (long?)Player3Id : null);

                var winner = new[] { ss, ss1, ss2 }.SingleOrDefault(a => a.HasValue);

                if (winner == default)
                {

                }

                return winner ??
                    0;
            }
        }


        public override bool Equals(object obj)
        {
            return Equals(obj as ThreeWayResult);
        }

        public bool Equals(ThreeWayResult other)
        {
            return other != null &&
                   base.Equals(other) &&
                   Player3Id == other.Player3Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Player3Id);
        }

        public static bool operator ==(ThreeWayResult left, ThreeWayResult right)
        {
            return EqualityComparer<ThreeWayResult>.Default.Equals(left, right);
        }

        public static bool operator !=(ThreeWayResult left, ThreeWayResult right)
        {
            return !(left == right);
        }
    }
}
