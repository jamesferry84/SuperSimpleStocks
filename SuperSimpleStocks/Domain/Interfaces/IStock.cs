namespace SuperSimpleStocks.Domain.Interfaces
{
    public interface IStock
    {
        StockType StockType { get; set; }
        double MarketPrice { get; set; }
        int LastDividend { get; set; }
        int ParValue { get; set; }
        string Symbol { get; set; }
        double VolumeWeightedStockPrice { get; set; }
        double FixedDividend { get; set; }
        double? ProfitToEarningsRatio { get; set; }
        double? DividendYield { get; set; }

    }
}
