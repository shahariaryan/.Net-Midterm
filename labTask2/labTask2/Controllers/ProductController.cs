using labTask2.Models;
using labTask2.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace labTask2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            Database db = new Database();
            var products = db.Products.GetAll();

            return View(products);
        }
        [HttpGet] 
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Add(p);
                return RedirectToAction("Index");

            }
            return View();
        }


        public ActionResult Edit(int Id)
        {

            return View();
        }
        public ActionResult Delete(int Id)
        {
            Database db = new Database();
            db.Products.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}