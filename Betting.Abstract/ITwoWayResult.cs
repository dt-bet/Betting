
using System;
using Betting.Enum;
using UtilityInterface.NonGeneric.Database;

namespace Betting.Abstract
{
    public interface ITwoWayResult : IGuid
    {
        Guid Player1Id { get; }
        AbsolutePosition Player1Status { get; }
        Guid Player2Id { get; }
        AbsolutePosition Player2Status { get; }
    }
}