using System;
using System.Collections.Generic;
using System.Linq;
using SuperSimpleStocks.Domain;
using SuperSimpleStocks.Services.Interfaces;

namespace SuperSimpleStocks.Services
{
    public class TradeService : ITradeService
    {

        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TradeService()
        {
            Trades = new List<Trade>();
        }

        public TradeService(ICollection<Trade> trades )
        {
            if (trades == null)
            {
                log.Error("trades cannot be null");
                throw new ArgumentNullException("trades");
            }
            Trades = trades;
        }

        public ICollection<Trade> Trades { get; set; }


        public void RecordTrade(Trade trade)
        {
            if (trade == null)
            {
                log.Error("Trade cannot be null");
                throw new ArgumentNullException("trade");
            }

            Trades.Add(trade);
        }

        public ICollection<Trade> GetAllTradesWIthinMinutesSpecified(string stockid, int minutes = 15)
        {
            if (minutes > 0)
                minutes *= -1;
            var dt = DateTime.Now;
            return Trades.Where(trade => trade.TimeOfTrade > dt.AddMinutes(minutes)).Where(trade => trade.Stock.Symbol.Equals(stockid)).ToList();
        }

        

        public double CalculateVolumeWeightedStockPrice(string stockId, int minutes = 15)
        {
            var trades = GetAllTradesWIthinMinutesSpecified(stockId, minutes);
            var totalValue = trades.Sum(trade => (trade.Price*trade.Quantity));
            if (trades.Sum(trade => trade.Quantity) == 0)
            {
                log.Info("Returning 0 as cannot divide by zero");
                return 0; 
            }
               
            return totalValue/(trades.Sum(trade => trade.Quantity));
        }

    }
}
