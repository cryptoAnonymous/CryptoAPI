using System.Linq;
using System.Web.Mvc;
using CryptoAPI.Models;
using CryptoAPI.Models.DataWrite;
using CryptoAPI.Models.Entites;

namespace CryptoAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            BittrexDataWriter bittrexWriter = new BittrexDataWriter();
            bittrexWriter.Start();

            filters.Add(new HandleErrorAttribute());
        }
    }
}
