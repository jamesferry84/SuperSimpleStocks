using System;
using System.Collections.Generic;
using System.Linq;
using SuperSimpleStocks.Domain;
using SuperSimpleStocks.Services.Interfaces;

namespace SuperSimpleStocks.Services
{
    public class StockService : IStockService
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public StockService()
        {
            Stocks = new List<Stock>();
        }

        public StockService(ICollection<Stock> stocks )
        {
            if (stocks == null)
            {
                log.Error("Stocks cannot be null");
                throw new ArgumentNullException("stocks");
            }
            Stocks = stocks;
        }

        public ICollection<Stock> Stocks { get; set; }

        public Stock GetStock(string symbol)
        {

            return Stocks.FirstOrDefault(x => x.Symbol == symbol);
        }

        public double CalculateAllShareIndex()
        {
            log.Info("Calculating all share index");
            if (Stocks.Count == 0 || Stocks == null)
            {
                log.Info("Returning 0 as stocks count was: " + Stocks.Count);
                return 0;
            }
               

            var totalMarketPrice = Stocks.Aggregate<Stock, double>(1, (current, stock) => current*stock.MarketPrice);
            return Math.Pow(totalMarketPrice, 1.0/Stocks.Count);
        }

        public double? CalculateDividendYield(Stock stock, double marketPrice)
        {
            log.Info("Calculating dividend yield");
            if (marketPrice == 0)
            {
                log.Info("Calculate dividend yield cannot divide by 0 so returning null");
                return null;
            }

            switch (stock.StockType)
            {
                case StockType.Preferred:
                    return (stock.FixedDividend * stock.ParValue) / marketPrice;
                default:
                    return stock.LastDividend / marketPrice;
            }
        }

        public double? CalculateProfitToEarningsRatio(Stock stock, double marketPrice)
        {
            log.Info("Calculating profit to earnings ratio");
            if (stock.LastDividend == 0)
            {
                log.Info("Calculate P/E Ratio cannot divide by 0 so returning null");
                return null;
            }

            return marketPrice / stock.LastDividend;
        }
    }
}
