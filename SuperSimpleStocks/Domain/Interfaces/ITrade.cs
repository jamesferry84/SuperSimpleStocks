using System;

namespace SuperSimpleStocks.Domain.Interfaces
{
    public interface ITrade
    {
        Stock Stock { get; set; }
        int TradeId { get; set; }
        DateTime TimeOfTrade { get; set; }
        int Quantity { get; set; }
        TradeDirection Direction { get; set; }
        double Price { get; set; }
    }
}
