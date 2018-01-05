using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoAPI.Models.Exchanges.Bittrex.JsonWrappers
{
    public class BittrexOrderBookWrapper
    {
        public string MarketName { get; set; }
        public ICollection<BittrexOrderWrapper> Orders { get; set; }

        public BittrexOrderBookWrapper()
        {
            Orders=new List<BittrexOrderWrapper>();
        }
    }
}