using System;
using System.Collections.Generic;
using SuperSimpleStocks.Domain;

namespace SuperSimpleStocksTests.Helpers
{

    public static class TestData
    {

        public static Stock GetTestCommonStock()
        {
            return new Stock
            {
                Symbol = "TEST_C",
                StockType = StockType.Common,
                LastDividend = 2,
                ParValue = 60
            };
        }

        public static Stock GetTestPreferredStock()
        {
            return new Stock
            {
                Symbol = "TEST_P",
                StockType = StockType.Preferred,
                LastDividend = 8,
                FixedDividend = 3 ,
                ParValue = 100
            };
        }

        public static ICollection<Stock> GetListOfEasyGeometricCalcStocks()
        {
            var stocks = new List<Stock>(5)
            {
                new Stock {Symbol = "TEST_C", StockType = StockType.Common, MarketPrice = 100},
                new Stock {Symbol = "TEST_P", StockType = StockType.Preferred, MarketPrice = 200}
        };


            return stocks;
        } 

        public static ICollection<Stock> GetListOfStocks()
        {
            var stocks = new List<Stock>(5)
            {
                new Stock {Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100},
                new Stock {Symbol = "POP", StockType = StockType.Common, LastDividend = 8, ParValue = 100},
                new Stock {Symbol = "ALE", StockType = StockType.Common, LastDividend = 23, ParValue = 60},
                new Stock {Symbol = "JOE", StockType = StockType.Common, LastDividend = 13, ParValue = 250},
                new Stock {Symbol = "TEST_C", StockType = StockType.Common, LastDividend = 2, ParValue = 60},

                new Stock {Symbol = "GIN", StockType = StockType.Preferred, LastDividend = 8, FixedDividend = 2, ParValue = 100},
                new Stock {Symbol = "TEST_P", StockType = StockType.Preferred, LastDividend = 8, FixedDividend = 3 , ParValue = 100}
        };


            return stocks;
        }

        public static ICollection<Trade> GetListOfTrades()
        {
            var trades = new List<Trade>(5)
            {
                new Trade(new Stock {Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100},100,50),
                new Trade(new Stock {Symbol = "POP", StockType = StockType.Common, LastDividend = 0, ParValue = 100},50,20),

            };

            var timedTrade = new Trade(new Stock { Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100 }, 50, 20);
            var time = DateTime.Now;
            timedTrade.TimeOfTrade = time.AddMinutes(-100);
            trades.Add(timedTrade);

            return trades;
        }

        public static Trade GetBuyTrade()
        {
            return new Trade(
                new Stock { Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100 }, 100, 50);
        }


        public static Trade GetBuyTradeQty100Price50WithSymbolTEA()
        {
            return new Trade(
                new Stock {Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100}, 100, 50);
        }

        public static Trade GetBuyTradeQty100Price50WithSymbolTEST()
        {
            return new Trade(
                new Stock { Symbol = "TEST", StockType = StockType.Common, LastDividend = 0, ParValue = 100 }, 100, 50);
        }

        public static Trade GetBuyTradeQty50Price10WithSymbolTEA()
        {
            return new Trade(
                new Stock { Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100 }, 50, 10);
        }

        public static Trade GetSellTrade()
        {
            return new Trade(
                new Stock { Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100 }, -50, 200);
        }

        public static Trade GetSellTradeQty50Price200WithSymbolTEA()
        {
            return new Trade(
                new Stock { Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100 }, -50, 200);
        }

        public static Trade GetSellTradeQty150Price20WithSymbolTEA()
        {
            return new Trade(
                new Stock { Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100 }, -150, 20);
        }
    }
}
