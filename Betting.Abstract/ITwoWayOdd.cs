using System;
using System.Collections.Generic;

namespace Betting.Abstract
{
    public interface ITwoWayOdd : IOdd
    {
        Guid Player1Id { get; }
        string Player1Name { get; }
        uint Player1Odd { get; }
        Guid Player2Id { get; }
        string Player2Name { get; }
        uint Player2Odd { get; }

        string ToString();
    }
}