
using UtilityEnum.Betting;

namespace Betting.Abstract
{
    public interface ITwoWayResult 
    {

        long Player1Id { get; }
        AbsolutePosition Player1Status { get; }
        long Player2Id { get; }
        AbsolutePosition Player2Status { get; }
    }
}