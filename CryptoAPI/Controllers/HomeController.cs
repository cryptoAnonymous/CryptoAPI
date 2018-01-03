using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CryptoAPI.Models.Exchanges.Bittrex.DataGetters;

namespace CryptoAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(new BittrexDataGetter().GetEntity("LTC", "BTC"));
        }
    }
}
