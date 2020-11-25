using System;
using System.Collections.Generic;

namespace Betting.Abstract
{
    public interface IThreeWayOdd : ITwoWayOdd
    {
        Guid Player3Id { get; }
        uint Player3Odd { get; }
        string Player3Name { get; set; }
    }
}