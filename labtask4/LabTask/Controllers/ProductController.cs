using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LabTask.Auth;
using LabTask.Models;

namespace LabTask.Controllers
{
    [UserAccess]
    public class ProductController : Controller
    {
  
       [AllowAnonymous]
        public ActionResult Index()
        {
            Entities db = new Entities();
            var productList = db.Products.ToList();
            return View(productList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Product p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.AddProduct(p);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Database db = new Database();
            var p = db.Products.GetProductById(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Update(Models.Product p,int id)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.UpdateProduct(p,id);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            Database db = new Database();
            db.Products.deleteProduct(id);
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public ActionResult ViewDetails(int id)
        {
            Database db = new Database();
            var p = db.Products.GetProductById(id);
            return View(p);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Card(int id)
        {
            List<Models.Product> products = null;
            Database db = new Database();
            var product = db.Products.GetProductById(id);

            if(Session["card"] == null)
            {
                products = new List<Models.Product>();
                products.Add(product);
                string json = new JavaScriptSerializer().Serialize(products);
                Session["card"] = json;
                return View(products);
            }
            else
            {
                var item = Session["card"].ToString();
                products = new JavaScriptSerializer().Deserialize<List<Models.Product>>(item);
                products.Add(product);
                string json = new JavaScriptSerializer().Serialize(products);
                Session["card"] = json;
                return View(products);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Cart()
        {
            List<Models.Product> products = new List<Models.Product>();
            var item = Session["card"].ToString();
            products = new JavaScriptSerializer().Deserialize<List<Models.Product>>((string)item);

            Database db = new Database();
            db.Orders.AddOrderToCard(products);

            Session["card"] = null;

            return RedirectToAction("MyOrder","order");
        }

    }
}