using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesCharts.Models;

namespace SalesCharts.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        // GET: Chart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Chart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Chart/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Dashboard()
        {
            DBModel dbModel = new DBModel();

            var listA = dbModel.Product.Where(x=>x.Name == "ProductA").ToList();
            var amountA = listA.Select(x => x.Amount);
            var listB = dbModel.Product.Where(x => x.Name == "ProductB").ToList();
            var amountB = listB.Select(x => x.Amount);

            var dates = listA.Select(x => x.Date).Distinct();
            


            ViewBag.AMOUNTA = amountA;
            ViewBag.AMOUNTB = amountB;
            ViewBag.DATES = dates;
            ViewBag.REP = amountA;


            return View();
        }
    }
}
