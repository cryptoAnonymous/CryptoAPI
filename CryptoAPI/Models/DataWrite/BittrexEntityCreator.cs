using System.IO;
using System.Linq;
using CryptoAPI.Models.Contexts;
using CryptoAPI.Models.Entites;
using CryptoAPI.Models.Entites.Bittrex;
using CryptoAPI.Models.Exchanges.Bittrex.JsonWrappers;

namespace CryptoAPI.Models.DataWrite
{
    public class BittrexEntityCreator
    {
        public BittrexSummaryEntity GetSummaryEntity(BittrexSummaryWrapper wrapper)
        {
            BittrexSummaryEntity entity = new BittrexSummaryEntity()
            {
                Ask = wrapper.Ask,
                Bid = wrapper.Bid,
                TimeStamp = wrapper.TimeStamp,
                Volume = wrapper.Volume,
            };
            return entity;
        }

        public Market GetMarketByName(string name)
        {
            Market market;
            using (BittrexContext db = new BittrexContext())
            {
                if (db.Markets.Count(p => p.Name == name) != 0)
                {
                    market= db.Markets.Where(p => p.Name == name).ToList()[0];
                }
                else
                {
                    market = new Market
                    {
                        Name = name
                    };
                    var exchange = db.Exchanges.Where(p => p.Name == BittrexContext.ExchangeName).ToList()[0];
                    market.Exchange=exchange;
                    market.ExchangeId = exchange.Id;
                }
            }
            return market;
        }
    }
}