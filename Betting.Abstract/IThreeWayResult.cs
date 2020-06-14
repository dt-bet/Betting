using UtilityEnum.Betting;

namespace Betting.Abstract
{
    public interface IThreeWayResult : ITwoWayResult
    {
        long Player3Id { get; }
        AbsolutePosition Player3Status { get; }

    }
}