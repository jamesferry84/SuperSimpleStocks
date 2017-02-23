using System;
using SuperSimpleStocks.Domain.Interfaces;

namespace SuperSimpleStocks.Domain
{
    public class Stock : IStock, IEquatable<IStock>
    {

        private double _fixedDividend;

        public string Symbol { get; set; }
        public StockType StockType { get; set; }
        public int LastDividend { get; set; }
        public int ParValue { get; set; }

        public double MarketPrice { get; set; }
        public double VolumeWeightedStockPrice { get; set; }
        public double? ProfitToEarningsRatio { get; set; }
        public double? DividendYield { get; set; }

        public double FixedDividend
        {
            get
            {
              return _fixedDividend / 100;  
            }
            set
            {
                _fixedDividend = value;
            }
        }

        public bool Equals(IStock other)
        {
            if (other == null)
                return false;

            return Symbol == other.Symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals(obj as IStock);
        }

        public override string ToString()
        {
            return $"Symbol: {Symbol}\n" +
                   $"Type: {StockType}\n" +
                   $"Last Dividend: {LastDividend}\n" +
                   $"Fixed Dividend: {FixedDividend}\n" +
                   $"Par Value: {ParValue}\n" +
                   $"Dividend Yield: {DividendYield}\n" +
                   $"P/E Ratio: {ProfitToEarningsRatio}\n" +
                   $"VWSP: {VolumeWeightedStockPrice}";
        }
    }
}
