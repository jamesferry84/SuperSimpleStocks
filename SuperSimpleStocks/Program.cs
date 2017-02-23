using System;
using System.Collections.Generic;
using SuperSimpleStocks.Domain;
using SuperSimpleStocks.Services;
using SuperSimpleStocks.Services.Interfaces;

namespace SuperSimpleStocks
{
    class Program
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static IStockService _stockService;
        private static ITradeService _tradeService;

        private const double MarketPrice = 102.0;

        static void Main(string[] args)
        {
            log.Info("Console application started");
            SetUpData();
            GivenMarketPriceAsInputCalculateDividendYield(MarketPrice);
            GivenMarketPriceAsInputCalculateProfitEarningRatio(MarketPrice);
            CalculateVolumeWeightedStockPriceForTradesBasedOnMinutes();
            RecordingTrade(SetupANewTradeForStock("TEA",-100,100));
            CalculateGbceAllShareIndex();

            Console.ReadLine();
            log.Info("Console application Completed");
        }

        static void GivenMarketPriceAsInputCalculateDividendYield(double marketPrice)
        {
            log.Info("Inside GivenMarketPriceAsInputCalculateDividendYield with marketPrice = " + marketPrice);
            Console.WriteLine("Calculating Dividend Yield....");

            foreach (var stock in _stockService.Stocks)
            {
                stock.MarketPrice = marketPrice;
                stock.DividendYield = _stockService.CalculateDividendYield(stock, marketPrice);

                Console.WriteLine("------");
                Console.WriteLine(stock);
            }
            Console.WriteLine("Completed Calculating Dividend Yield");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            log.Info("GivenMarketPriceAsInputCalculateDividendYield Completed ");
        }

        static void GivenMarketPriceAsInputCalculateProfitEarningRatio(double marketPrice)
        {
            log.Info("Inside GivenMarketPriceAsInputCalculateProfitEarningRatio with marketPrice = " + marketPrice);
            Console.WriteLine("Calculating P/E Ratio....");

            foreach (var stock in _stockService.Stocks)
            {
                stock.MarketPrice = marketPrice;
                stock.ProfitToEarningsRatio = _stockService.CalculateProfitToEarningsRatio(stock, marketPrice);

                Console.WriteLine("------");
                Console.WriteLine(stock);
            }
            Console.WriteLine("Completed P/E Ratio");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            log.Info("GivenMarketPriceAsInputCalculateProfitEarningRatio Completed");
        }

        static void RecordingTrade(Trade trade)
        {
            Console.WriteLine("Record Trade");

            _tradeService.Trades.Add(trade);
            Console.WriteLine(trade);

            Console.WriteLine("##ALL TRADES##");
            DisplayAllTrades();
            Console.WriteLine("##############");

            Console.WriteLine("Completed Record Trade");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
        }

        static void CalculateVolumeWeightedStockPriceForTradesBasedOnMinutes(int minutes = 15)
        {
            log.Info("Inside CalculateVolumeWeightedStockPriceForTradesBasedOnMinutes : " + minutes + " minutes");
            Console.WriteLine("Calculating Volume Weighted Stock Price for all trades placed in last 15 minutes....");

            foreach (var stock in _stockService.Stocks)
            {
                stock.VolumeWeightedStockPrice = _tradeService.CalculateVolumeWeightedStockPrice(stock.Symbol, minutes);

                Console.WriteLine("------");
                Console.WriteLine(stock);
            }
            Console.WriteLine("Completed Calculating Volume Weighted Stock Price");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();

            log.Info("CalculateVolumeWeightedStockPriceForTradesBasedOnMinutes Completed");
        }

        static void CalculateGbceAllShareIndex()
        {
            log.Info("Inside CalculateGbceAllShareIndex");
            Console.WriteLine("Calculating GBCE All Share Index....");

            Console.WriteLine("GBCE All Share Index = " + _stockService.CalculateAllShareIndex());
            Console.WriteLine("Completed GBCE All Share Index");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            log.Info("CalculateGbceAllShareIndex Completed");
        }

        static void DisplayAllStocks()
        {
            log.Info("Inside DisplayAllStocks");
            foreach (var stock in _stockService.Stocks)
            {
                Console.WriteLine("------");
                Console.WriteLine(stock);
            }
            log.Info("DisplayAllStocks Completed");
        }

        static void DisplayAllTrades()
        {
            log.Info("Inside DisplayAllTrades");
            foreach (var trade in _tradeService.Trades)
            {
                Console.WriteLine("------");
                Console.WriteLine(trade);
            }
            log.Info("DisplayAllStocks Completed");
        }

        static void SetUpData()
        {
            log.Info("Inside SetUpData");
            var stocks = new List<Stock>(5)
            {
                new Stock {Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100},
                new Stock {Symbol = "POP", StockType = StockType.Common, LastDividend = 8, ParValue = 100},
                new Stock {Symbol = "ALE", StockType = StockType.Common, LastDividend = 23, ParValue = 60},
                new Stock {Symbol = "GIN", StockType = StockType.Preferred, LastDividend = 8, FixedDividend = 2, ParValue = 100},
                new Stock {Symbol = "JOE", StockType = StockType.Common, LastDividend = 13, ParValue = 250}

            };

            var trades = new List<Trade>(5)
            {
                new Trade(new Stock {Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100},100,50),
                new Trade(new Stock {Symbol = "POP", StockType = StockType.Common, LastDividend = 8, ParValue = 100},50,20),

            };

            _stockService = new StockService(stocks);
            _tradeService = new TradeService(trades);

            log.Info("SetUpData Complete");

        }



        static Trade SetupANewTradeForStock(string stockSymbol, int qty, double price)
        {
            log.Info("SetupANewTradeForStock: symbol: " + stockSymbol + " QTY: " + qty + "Price: "  + price);
            return new Trade(_stockService.GetStock(stockSymbol),qty, price);
        }
    }
}
