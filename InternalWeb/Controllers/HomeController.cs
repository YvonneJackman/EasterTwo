namespace InternalWeb.Controllers
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
            ViewBag.Message = "Internal Website Application.";

            return this.View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Internal Website Application.";

            return this.View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How to get in touch.";

            return this.View();
        }
    }
}
