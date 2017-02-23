using System.Collections.Generic;
using SuperSimpleStocks.Domain;

namespace SuperSimpleStocks.Services.Interfaces
{
    public interface IStockService
    {
        ICollection<Stock> Stocks { get; set; }
        Stock GetStock(string symbol);
        double CalculateAllShareIndex();
        double? CalculateDividendYield(Stock stock, double marketPrice);
        double? CalculateProfitToEarningsRatio(Stock stock, double marketPrice);

    }
}
