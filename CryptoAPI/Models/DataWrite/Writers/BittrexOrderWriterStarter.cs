using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using CryptoAPI.Models.Contexts;

namespace CryptoAPI.Models.DataWrite.Writers
{
    public class BittrexOrderWriterStarter:Writer
    {
        protected override void Write()
        {
            List<Writer> pool = new List<Writer>();
            using (BittrexContext db = new BittrexContext())
            {
                foreach (var market in db.Markets)
                {
                    Writer thread = new BittrexOrdersWriter(market.Name);
                    thread.Start();
                    pool.Add(thread);
                    Thread.Sleep(2000);
                }
            }

        }
    }
}