using System;
using System.Collections.Generic;

namespace CryptoAPI.Models.Entites.Bittrex
{
    public class BittrexOrderBook
    {
        public int MarketId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Id { get; set; }
        public Market Market { get; set; }

        public ICollection<BittrexOrder> Orders { get; set; }

        public BittrexOrderBook()
        {
            Orders=new List<BittrexOrder>();
        }
    }
}