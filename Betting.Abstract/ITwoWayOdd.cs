using System;
using System.Collections.Generic;

namespace Betting.Abstract
{
    public interface ITwoWayOdd : IOdd
    {

        long Player1Id { get; set; }
        string Player1Name { get; set; }
        uint Player1Odd { get; set; }
        long Player2Id { get; set; }
        string Player2Name { get; set; }
        uint Player2Odd { get; set; }

        string ToString();
    }
}