
using System;
using Betting.Enum;

namespace Betting.Abstract
{
    public interface ITwoWayResult 
    {
        Guid Guid { get; set; }
        Guid Player1Id { get; }
        AbsolutePosition Player1Status { get; }
        Guid Player2Id { get; }
        AbsolutePosition Player2Status { get; }
    }
}