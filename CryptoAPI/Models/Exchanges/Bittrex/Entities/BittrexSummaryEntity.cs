
using System;

namespace CryptoAPI.Models.Exchanges.Bittrex.Entities
{
    public class BittrexSummaryEntity
    {
        public string MarketName { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }
        public DateTime TimeStamp { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
    }
}