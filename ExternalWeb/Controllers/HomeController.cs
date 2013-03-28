namespace ExternalWeb.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "External Website Application.";

            return this.View(this);
        }

        public ActionResult About()
        {
            ViewBag.Message = "External Website Application.";

            return this.View(this);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How to get in touch.";

            return this.View(this);
        }
    }
}
