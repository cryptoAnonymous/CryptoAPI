using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CryptoAPI.Models.Contexts;
using CryptoAPI.Models.DataWrite.Writers;

namespace CryptoAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            Writer bittrexWriter = new BittrexSummariesWriter();
            bittrexWriter.Start();

            Writer orderWriter = new BittrexOrderWriterStarter();
            orderWriter.Start();

            filters.Add(new HandleErrorAttribute());
        }
    }
}
