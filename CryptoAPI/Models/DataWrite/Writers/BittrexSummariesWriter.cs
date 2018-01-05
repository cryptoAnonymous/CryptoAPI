using System.Collections.Generic;
using System.Threading;
using CryptoAPI.Models.Contexts;
using CryptoAPI.Models.Entites;
using CryptoAPI.Models.Entites.Bittrex;
using CryptoAPI.Models.Exchanges.Bittrex.JsonWrappers;

namespace CryptoAPI.Models.DataWrite.Writers
{
    public class BittrexSummariesWriter:Writer
    {
        protected override void Write()
        {
            while (true)
            {
                using (BittrexContext db = new BittrexContext())
                {
                    List<BittrexSummaryWrapper> summaries = DataGetter.GetEntities();
                    foreach (var summary in summaries)
                    {
                        BittrexSummaryEntity entity = Creator.GetSummaryEntity(summary);
                        Market market = Creator.GetMarketByName(summary.MarketName);
                        if (market.Id == 0)
                            entity.Market = market;
                        entity.MarketId = market.Id;
                        db.Summaries.Add(entity);
                    }
                    db.SaveChanges();
                }


                Thread.Sleep(300000);
            }
        }
    }
}