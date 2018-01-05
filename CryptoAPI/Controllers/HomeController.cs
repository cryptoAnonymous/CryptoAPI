using System.Web.Mvc;
using CryptoAPI.Models.Exchanges.Bittrex.DataGetters;

namespace CryptoAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var test = new BittrexDataGetter().GetEntity("BTC", "LTC");
            return View(test);
        }
    }
}
