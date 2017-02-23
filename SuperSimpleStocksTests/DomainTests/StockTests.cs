using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperSimpleStocks.Domain;

namespace SuperSimpleStocksTests.DomainTests
{
    [TestClass]
    public class StockTests
    {

        [TestMethod]
        public void FixedDividendGivenWholeNumberDivideByOneHundredToRepresentPercentage()
        {
            var stock = new Stock();
            const int fixedDividend = 100;
            const int expected = 100/100;
            stock.FixedDividend = fixedDividend;

            Assert.AreEqual(expected, stock.FixedDividend);
        }

        [TestMethod]
        public void CheckEqualityBasedOnSymbol()
        {
            var stockOne = new Stock();
            var stockTwo = new Stock();
            stockOne.Symbol = "TEST";
            stockTwo.Symbol = "TEST";

            Assert.AreEqual(stockOne, stockTwo);

        }
    }
}
