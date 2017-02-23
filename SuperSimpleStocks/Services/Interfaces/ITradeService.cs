using System.Collections.Generic;
using SuperSimpleStocks.Domain;

namespace SuperSimpleStocks.Services.Interfaces
{
    public interface ITradeService
    {
        ICollection<Trade> Trades { get; set; } 

        void RecordTrade(Trade trade);
        ICollection<Trade> GetAllTradesWIthinMinutesSpecified(string stockid, int minutes);
        double CalculateVolumeWeightedStockPrice(string stockid, int minutes);
    }
}
