using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperSimpleStocks.Domain;
using SuperSimpleStocks.Services;
using SuperSimpleStocks.Services.Interfaces;
using SuperSimpleStocksTests.Helpers;

namespace SuperSimpleStocksTests.ServiceTests
{
    [TestClass]
    public class StockServiceTests
    {

        [TestMethod]
        public void CtorGivenAListOfStocksCreateStockManagerWithStocks()
        {
            var stocks = TestData.GetListOfStocks();
            var stockService = new StockService(stocks);

            Assert.IsNotNull(stockService.Stocks);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Stocks cannot be null")]
        public void CtorGivenUninitializedStocksCreateStockManagerWithStocksThrowArgumentNullException()
        {
            new StockService(null);
        }

        [TestMethod]
        public void GivenAStockIdentifierReturnStock()
        {
            var stocks = TestData.GetListOfStocks();
            IStockService stockService = new StockService(stocks);
            var expectedValue = TestData.GetTestCommonStock();
 

            var actualValue = stockService.GetStock("TEST_C");

            Assert.AreEqual(expectedValue,actualValue);
        }

        [TestMethod]
        public void GivenAStockIdentifierThatDoesNotExistReturnNull()
        {
            var stocks = TestData.GetListOfStocks();
            IStockService stockService = new StockService(stocks);

            var actualValue = stockService.GetStock("DoesNotExist");

            Assert.AreEqual(null, actualValue);
        }

        [TestMethod]
        public void GivenAListOfStocksCalculateAllShareIndex()
        {
            var stocks = TestData.GetListOfEasyGeometricCalcStocks();
            IStockService stockService = new StockService(stocks);
            const int marketPriceOne = 100;
            const int marketPriceTwo = 200;
            const int stockCount = 2;
            double expectedValue = marketPriceOne * marketPriceTwo;
            expectedValue = Math.Pow(expectedValue, 1.0/stockCount);

            var actualValue = stockService.CalculateAllShareIndex();

            Assert.AreEqual(expectedValue,actualValue);
        }

        [TestMethod]
        public void GivenNoStocksCalculateAllShareIndexReturnZero()
        {
            var stocks = new List<Stock>();
            IStockService stockService = new StockService(stocks);
            const int expected = 0;
            var actual = stockService.CalculateAllShareIndex();

            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GivenMarketPriceIsZeroCalculateDividendYieldForCommonStockReturnNull()
        {
            var stock = TestData.GetTestCommonStock();
            var stockManager = new StockService();
            const double marketPrice = 0.0;
            double? expected = null;
            var actual = stockManager.CalculateDividendYield(stock, marketPrice);

            Assert.AreEqual(expected,actual);
        }


        [TestMethod]
        public void GivenMarketPriceCalculateDividendYieldForCommonStock()
        {
            var stock = TestData.GetTestCommonStock();
            var stockManager = new StockService();
            const double marketPrice = 100;
            const double lastDividend = 2;

            const double expectedValue = lastDividend / marketPrice;
            var actualValue = stockManager.CalculateDividendYield(stock, marketPrice);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void GivenMarketPriceCalculateDividendYieldForPreferredStock()
        {
            var stockManager = new StockService();

            var stock = TestData.GetTestPreferredStock();
            const double marketPrice = 821;
            const double fixedDividend = 0.03;
            const double parValue = 100;

            const double expectedValue = (fixedDividend * parValue) / marketPrice;
 
            var actualValue = stockManager.CalculateDividendYield(stock, marketPrice);
            
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void GivenZeroLastDividendCalculateProfitToEarningsRatioReturnNull()
        {
            var stock = TestData.GetTestCommonStock();
            stock.LastDividend = 0;
            var stockManager = new StockService();
            const double marketPrice = 100;
            double? expected = null;

            var actual = stockManager.CalculateProfitToEarningsRatio(stock, marketPrice);
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GivenMarketPriceCalculateProfitToEarningsRatio()
        {
            var stock = TestData.GetTestCommonStock();
            var stockManager = new StockService();
            const double marketPrice = 926;
            const double lastDividend = 2;

            const double expectedValue = marketPrice / lastDividend;

            var actualValue = stockManager.CalculateProfitToEarningsRatio(stock, marketPrice);

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
