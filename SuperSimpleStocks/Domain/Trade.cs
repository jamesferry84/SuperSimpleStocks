using System;
using SuperSimpleStocks.Domain.Interfaces;

namespace SuperSimpleStocks.Domain
{
    public class Trade : ITrade, IEquatable<ITrade>
    {

        public Stock Stock { get; set; }
        public int TradeId { get; set; }
        public DateTime TimeOfTrade { get; set; }
        public int Quantity { get; set; }
        public TradeDirection Direction { get; set; }
        public double Price { get; set; }


        public Trade(Stock stock, int quantity, double price)
        {
            if (quantity == 0) throw new ArgumentNullException("quantity");
            if (stock == null) throw new ArgumentNullException("stock");

            Stock = stock;
            TimeOfTrade = DateTime.Now;
            Quantity = quantity;
            Price = price;
            Direction = quantity >= 0 ? TradeDirection.Buy : TradeDirection.Sell;
        }

        public bool Equals(ITrade other)
        {
            if (other == null)
                return false;

            return TradeId == other.TradeId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals(obj as ITrade);
        }

        public override string ToString()
        {
            return $"Stock:\n{Stock}\n" +
                   $"TimeOfTrade: {TimeOfTrade}\n" +
                   $"QTY: {Quantity}\n" +
                   $"Price: {Price}\n" +
                   $"Direction: {Direction}\n";
        }
    }
}
