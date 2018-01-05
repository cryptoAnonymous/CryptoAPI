using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CryptoAPI.Models.Entites.Bittrex;

namespace CryptoAPI.Models.Exchanges.Bittrex.JsonWrappers
{
    public class BittrexSummaryWrapper
    {
        public string MarketName { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }
        public DateTime TimeStamp { get; set; }
        public double Volume { get; set; }
    }
}