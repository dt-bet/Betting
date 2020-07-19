using System.Threading.Tasks;

namespace Betting.Abstract
{
    public interface IResultsAsync
    {
        Task<IResult[]> Results { get; }
    }
}