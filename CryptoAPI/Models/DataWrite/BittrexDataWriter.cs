using System.Collections.Generic;
using System.Threading;
using CryptoAPI.Models.Contexts;
using CryptoAPI.Models.Entites;
using CryptoAPI.Models.Entites.Bittrex;
using CryptoAPI.Models.Exchanges.Bittrex.DataGetters;
using CryptoAPI.Models.Exchanges.Bittrex.JsonWrappers;

namespace CryptoAPI.Models.DataWrite
{
    public class BittrexDataWriter
    {
        private Thread _writer;
        public BittrexDataGetter DataGetter { get; }

        public BittrexDataWriter()
        {
            DataGetter=new BittrexDataGetter();
        }

        public void Start()
        {
            _writer=new Thread(Write);
            _writer.Start();
        }

        public void Stop()
        {
            _writer.Interrupt();
        }

        private void Write()
        {
            while (true)
            {
                using (BittrexContext db = new BittrexContext())
                {
                    BittrexEntityCreator creator = new BittrexEntityCreator();
                    List<BittrexSummaryWrapper> summaries = DataGetter.GetEntities();
                    foreach (var summary in summaries)
                    {
                        BittrexSummaryEntity entity = creator.GetSummaryEntity(summary);
                        Market market = creator.GetMarketByName(summary.MarketName);
                        if (market.Id == 0)
                            entity.Market = market;
                        entity.MarketId = market.Id;
                        db.Summaries.Add(entity);
                    }
                    db.SaveChanges();
                }

                Thread.Sleep(10000);
            }
        }
    }
}