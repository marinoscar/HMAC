using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hmac.Web.Controllers
{
    public class HomeController : Controller
    {

        private HmacProvider _provider;

        public HmacProvider Provider
        {
            get { return _provider ?? (_provider = new HmacProvider()); }
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetRandomKey()
        {
            return Json(Provider.GetRandomKey(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetSignature(string secretKey, string data)
        {
            return Json(Provider.GetSignature(secretKey, data), JsonRequestBehavior.AllowGet);
        }
	}

    public class ContentData
    {
        public string SecretKey { get; set; }
        public string Data { get; set; }
    }
}