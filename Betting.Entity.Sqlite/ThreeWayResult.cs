using Betting.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using Betting.Enum;
using Dapper.Contrib.Extensions;

namespace Betting.Entity.Sqlite
{
    [Dapper.Contrib.Extensions.Table("Result")]
    [SQLite.Table("Result")]
    public class ThreeWayResult : TwoWayResult, IThreeWayResult, IEquatable<ThreeWayResult>
    {
        public ThreeWayResult(Guid marketId,
            Guid player1Id, AbsolutePosition player1Status,
            Guid player2Id, AbsolutePosition player2Status,
            Guid player3Id, AbsolutePosition player3Status
            ) : base(marketId, marketId, player1Id, player1Status, player2Id, player2Status)
        {
            Player3Id = player3Id;
            Player3Status = player3Status;
        }

        public ThreeWayResult(Guid guid, Guid marketId,
    Guid player1Id, AbsolutePosition player1Status,
    Guid player2Id, AbsolutePosition player2Status,
    Guid player3Id, AbsolutePosition player3Status
    ) : base(guid, marketId, player1Id, player1Status, player2Id, player2Status)
        {
            Player3Id = player3Id;
            Player3Status = player3Status;
        }

        public ThreeWayResult()
        {
        }

        public Guid Player3Id { get; set; }


        [SQLite.Indexed]
        public AbsolutePosition Player3Status { get; set; }

        [Write(false)]
        [SQLite.Ignore]
        public override Guid WinnerId
        {
            get
            {
                Guid? ss = (Player1Status == AbsolutePosition.Winner
                            && Player2Status == AbsolutePosition.Loser
                            && Player3Status == AbsolutePosition.Loser ? (Guid?)Player1Id : null);

                Guid? ss1 = (Player1Status == AbsolutePosition.Loser
                            && Player2Status == AbsolutePosition.Winner
                            && Player3Status == AbsolutePosition.Loser ? (Guid?)Player2Id : null);

                Guid? ss2 = (Player1Status == AbsolutePosition.Loser
                            && Player2Status == AbsolutePosition.Loser
                            && Player3Status == AbsolutePosition.Winner ? (Guid?)Player3Id : null);

                var winner = new[] { ss, ss1, ss2 }.SingleOrDefault(a => a.HasValue);

                if (winner == default)
                {

                }

                return winner ??                    default;
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
