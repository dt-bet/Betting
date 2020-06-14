using System.Collections.Generic;

namespace Betting.Abstract
{
    public interface IThreeWayOdd : ITwoWayOdd
    {
        long Player3Id { get; set; }
        uint Player3Odd { get; set; }
    }
}