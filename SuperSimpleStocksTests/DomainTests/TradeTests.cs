using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperSimpleStocks.Domain;

namespace SuperSimpleStocksTests.DomainTests
{
    [TestClass]
    public class TradeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Stock cannot be null")]
        public void ctorGivenNullStockThrowException()
        {
            new Trade(null, 100,100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Qty cannot be null")]
        public void ctorGivenZeroQtyThrowException()
        {
            new Trade(new Stock(), 0, 100);
        }

        [TestMethod]
        public void ctorGivenPositiveQtyTradeDirectionIsBUY()
        {
            var trade = new Trade(new Stock(), 100, 100);

            Assert.AreEqual(TradeDirection.Buy, trade.Direction);
        }

        [TestMethod]
        public void ctorGivenNegativeQtyTradeDirectionIsSELL()
        {
            var trade = new Trade(new Stock(), -100, 100);

            Assert.AreEqual(TradeDirection.Sell, trade.Direction);
        }
    }
}
