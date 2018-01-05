
using System;

namespace CryptoAPI.Models.Entites.Bittrex
{
    public class BittrexSummaryEntity
    {
        public int Id { get; set; }
        public int MarketId { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }
        public DateTime TimeStamp { get; set; }
        public double Volume { get; set; }
        public Market Market { get; set; }

    }
}