using System.IO;
using System.Threading;
using CryptoAPI.Models.Contexts;

namespace CryptoAPI.Models.DataWrite.Writers
{
    public class BittrexOrdersWriter : Writer
    {
        private string _marketName;

        public BittrexOrdersWriter(string marketName):base()
        {
            _marketName = marketName;
        }
        protected override void Write()
        {
            using (BittrexContext db = new BittrexContext())
            {
                var orderBook = Creator.GetOrderBook(DataGetter.GetOrdersBook(_marketName));
                db.OrderBooks.Add(orderBook);
                db.SaveChanges();
            }

            Thread.Sleep(300000);
        }
    }
}