using labTask2.Models;
using labTask2.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Database db = new Database();
            var p = db.Products.Get(Id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Edit(p);
                return RedirectToAction("Index");

            }
            return View(p);
        }

        public ActionResult Delete(int Id)
        {
            Database db = new Database();
            db.Products.Delete(Id);
            return RedirectToAction("Index");
        }

        public ActionResult Cart(int Id)
        {
            List<Product> cartProducts = null;
            Database db = new Database();

            var SoloProduct = db.Products.Get(Id);
            if (Session["cart"] == null)
            {
                cartProducts = new List<Product>();

                cartProducts.Add(SoloProduct);
                string cart = new JavaScriptSerializer().Serialize(cartProducts);
                Session["cart"] = cart;

            }
            else
            {
                var previousCart = Session["cart"].ToString();
                cartProducts = new JavaScriptSerializer().Deserialize<List<Product>>(previousCart);
                cartProducts.Add(SoloProduct);
                string cart = new JavaScriptSerializer().Serialize(cartProducts);
                Session["cart"] = cart;

            }
            return View(cartProducts);

        }

    }
}