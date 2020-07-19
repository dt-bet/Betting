using System;
using System.Collections.Generic;

namespace Betting.Abstract
{
    public interface IThreeWayOdd : ITwoWayOdd
    {
        Guid Player3Id { get; set; }
        uint Player3Odd { get; set; }
    }
}