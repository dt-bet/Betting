namespace Betting.Abstract
{
    public interface ICurrentProfit
    {
        long Amount { get; set; }

        string MarketId { get; set; }

        long SelectionId { get; set; }
    }
}