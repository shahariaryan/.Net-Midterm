using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using work3_ORM.Models;

namespace work3_ORM.Controllers
{

    public class ProductController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            ZOZOEntities1 db = new ZOZOEntities1();
            var data = db.Products.ToList();

            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Product p)
        {
            ZOZOEntities1 db = new ZOZOEntities1();
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            ZOZOEntities1 db = new ZOZOEntities1();
            var product = (from pd in db.Products
                           where pd.Id == Id
                           select pd).First();
            return View(product);

        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            using (ZOZOEntities1 db = new ZOZOEntities1())
            {

                var product = (from pd in db.Products
                               where pd.Id == p.Id
                               select pd).FirstOrDefault();
                /*product.Name = p.Name;
                product.Price = p.Price;
                product.Quantity = p.Quantity;
                product.Description = p.Description;
                db.SaveChanges();
                return RedirectToAction("Index");
            }*/

                db.Entry(product).CurrentValues.SetValues(p); //current value of model replaced by new model
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // var product = db.Products.FirstOrDefault(e => e.Id == p.Id);
            // db.Entry(product).CurrentValues.SetValues(p);



        }
        public ActionResult Delete(int Id)
        {
            using (ZOZOEntities1 db = new ZOZOEntities1())
            {
                var products = (from pd in db.Products
                                where pd.Id == Id
                                select pd).FirstOrDefault();
                return View(products);
            }



        }
        [HttpPost]
        public ActionResult Delete(Product p)
        {
            using (ZOZOEntities1 db = new ZOZOEntities1())
            {
                var e = (from pd in db.Products
                         where pd.Id == p.Id
                         select pd).FirstOrDefault();

                db.Products.Remove(e);
                db.SaveChanges();
                return RedirectToAction("Index");
            }




        }



    }
}

    
