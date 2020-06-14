namespace Betting.Abstract
{
    public interface IPrice
    {
        System.Guid OddId { get; set; }

        string MarketId { get; set; }

        string Name { get; set; }

        long SelectionId { get; set; }

        uint Value { get; set; }
    }
}