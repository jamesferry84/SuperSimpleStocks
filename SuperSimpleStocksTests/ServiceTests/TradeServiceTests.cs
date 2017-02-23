using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperSimpleStocks.Services;
using SuperSimpleStocksTests.Helpers;

namespace SuperSimpleStocksTests.ServiceTests
{
    [TestClass]
    public class TradeServiceTests
    {
        [TestMethod]
        public void CtorGivenAListOfStocksCreateStockManagerWithStocks()
        {
            var trades = TestData.GetListOfTrades();
            var tradeService = new TradeService(trades);

            Assert.IsNotNull(tradeService.Trades);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Trades cannot be null")]
        public void CtorGivenUninitializedStocksCreateStockManagerWithStocksThrowArgumentNullException()
        {
            new TradeService(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Trade cannot be null")]
        public void GivenANewTradeIsNullThenAddToTradesThrowArgumentNullException()
        {
            var tradeService = new TradeService();
            tradeService.RecordTrade(null);
        }

        [TestMethod]
        public void GivenANewTradeRecordThenAddToTrades()
        {
            var tradeService = new TradeService();
            var expected = tradeService.Trades.Count + 1;
            tradeService.RecordTrade(TestData.GetBuyTrade());

            var actual = tradeService.Trades.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllTradesInLastFifteenMinutes()
        {
            var tradeService = new TradeService(TestData.GetListOfTrades());
            const int expected = 1;
            var tradesLastFifteen = tradeService.GetAllTradesWIthinMinutesSpecified("TEA");

            var actual = tradesLastFifteen.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateVolumeWeightedStockPriceTestGivenTwoTradesAllWithSameSymbol()
        {
            var tradeService = new TradeService();
            tradeService.Trades.Add(TestData.GetBuyTradeQty100Price50WithSymbolTEA());
            tradeService.Trades.Add(TestData.GetBuyTradeQty50Price10WithSymbolTEA());

            const double tradeOnePrice = 50;
            const double tradeOneQty = 100;
            const double tradeOneTotalValue = tradeOneQty*tradeOnePrice;

            const double tradeTwoPrice = 10;
            const double tradeTwoQty = 50;
            const double tradeTwoTotalValue = tradeTwoQty * tradeTwoPrice;

            const double totalValue = tradeOneTotalValue + tradeTwoTotalValue;
            const double totalQty = tradeOneQty + tradeTwoQty;

            const double expected = totalValue/totalQty;

            var actual = tradeService.CalculateVolumeWeightedStockPrice("TEA");

            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void CalculateVolumeWeightedStockPriceTestGivenThreeTradesTwoWithSameSymbol()
        {
            var tradeService = new TradeService();
            tradeService.Trades.Add(TestData.GetBuyTradeQty100Price50WithSymbolTEA());
            tradeService.Trades.Add(TestData.GetBuyTradeQty50Price10WithSymbolTEA());
            tradeService.Trades.Add(TestData.GetBuyTradeQty100Price50WithSymbolTEST());

            const double tradeOnePrice = 50;
            const double tradeOneQty = 100;
            const double tradeOneTotalValue = tradeOneQty * tradeOnePrice;

            const double tradeTwoPrice = 10;
            const double tradeTwoQty = 50;
            const double tradeTwoTotalValue = tradeTwoQty * tradeTwoPrice;

            const double totalValue = tradeOneTotalValue + tradeTwoTotalValue;
            const double totalQty = tradeOneQty + tradeTwoQty;

            const double expected = totalValue / totalQty;

            var actual = tradeService.CalculateVolumeWeightedStockPrice("TEA");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateVolumeWeightedStockPriceGivenQtyTotalsZeroThenReturnZero()
        {
            var tradeService = new TradeService();
            tradeService.Trades.Add(TestData.GetBuyTradeQty50Price10WithSymbolTEA());
            tradeService.Trades.Add(TestData.GetSellTradeQty50Price200WithSymbolTEA());
            const int expected = 0;
            var actual = tradeService.CalculateVolumeWeightedStockPrice("TEA");

            Assert.AreEqual(expected,actual);
        }

    }
}
