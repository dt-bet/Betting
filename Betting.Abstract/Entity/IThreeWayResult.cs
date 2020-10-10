using System;
using Betting.Enum;

namespace Betting.Abstract
{
    public interface IThreeWayResult : ITwoWayResult
    {
        Guid Player3Id { get; }

        AbsolutePosition Player3Status { get; }

    }
}