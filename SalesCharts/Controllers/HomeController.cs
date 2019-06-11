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
        /// <summary>Indexes this instance.</summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>Products a.</summary>
        /// <returns></returns>
        public ActionResult ProductA()
        {
            using (DBModel dBModel = new DBModel())
            {
                return View(dBModel.Product.Where(x=>x.Name=="ProductA").ToList());
            }
        }

        /// <summary>Products the b.</summary>
        /// <returns></returns>
        public ActionResult ProductB()
        {
            using (DBModel dBModel = new DBModel())
            {
                return View(dBModel.Product.Where(x => x.Name == "ProductB").ToList());
            }
        }

        /// <summary>Products this instance.</summary>
        /// <returns></returns>
        public ActionResult Product()
        {
            ViewBag.Message = "Your product page.";

            return View();
        }
    }
}