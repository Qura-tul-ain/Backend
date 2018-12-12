using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace online.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            onlineEntities db = new onlineEntities();
            List<Product> lists = new List<Product>();
            lists = db.Products.ToList();
            return View(lists);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}