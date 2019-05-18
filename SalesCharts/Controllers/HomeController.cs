using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesCharts.Models;

namespace SalesCharts.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductA()
        {
            using (DBModel dBModel = new DBModel())
            {
                return View(dBModel.Product.Where(x=>x.Name=="ProductA").ToList());
            }
        }

        public ActionResult ProductB()
        {
            using (DBModel dBModel = new DBModel())
            {
                return View(dBModel.Product.Where(x => x.Name == "ProductB").ToList());
            }
        }

        public ActionResult Product()
        {
            ViewBag.Message = "Your product page.";

            return View();
        }
    }
}