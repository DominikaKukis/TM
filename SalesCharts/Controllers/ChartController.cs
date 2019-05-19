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

        public ActionResult Dashboard() //Podaż -supply
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

            return View();
        }

        public ActionResult Demand() //Popyt
        {
            DBModel dbModel = new DBModel();
            Random rand = new Random();
            
            var listA = dbModel.Product.Where(x => x.Name == "ProductA").ToList();
            var amountA = listA.Select(x => x.Amount);

            var listAA = new List<int>();

            for(int i=0; i < amountA.Count(); i++)
            {
                var a = rand.Next(1000) + 100;
                listAA.Add(a);
            }

            var listB = dbModel.Product.Where(x => x.Name == "ProductB").ToList();
            var amountB = listB.Select(x => x.Amount);

            var listBB = new List<int>();

            for (int i = 0; i < amountB.Count(); i++)
            {
                var a = rand.Next(1000) + 100;
                listBB.Add(a);
            }

            var dates = listA.Select(x => x.Date).Distinct();

            ViewBag.LISTAA = listAA;
            ViewBag.LISTBB = listBB;
            ViewBag.DATES = dates;

            return View();
        }

        public ActionResult Income() //Przychód
        {
            DBModel dbModel = new DBModel();

            var listA = dbModel.Product.Where(x => x.Name == "ProductA").ToList();
            var incomeA = new List<double>();

            for (int i = 0; i < listA.Count(); i++)
            {
                var a = listA.Where(x => x.Id == (i + 1)).First();
                double price = a.Price;
                double provision = a.Provision;
                double sum = price + provision;
                incomeA.Add(sum);

            }

            var listB = dbModel.Product.Where(x => x.Name == "ProductB").ToList();
            var incomeB = new List<double>();

            for (int i = 0; i < listB.Count(); i++)
            {
                var b = listB[i];
                if (b != null)
                {
                    double price = b.Price;
                    double provision = b.Provision;
                    double sum = price + provision;
                    incomeB.Add(sum);
                }
            }

            var dates = listA.Select(x => x.Date).Distinct();

            ViewBag.DATES = dates;
            ViewBag.incomeA = incomeA;
            ViewBag.incomeB = incomeB;
            return View();
        }
    }
}
