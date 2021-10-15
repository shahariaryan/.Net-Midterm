using LabTask.Auth;
using LabTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask.Controllers
{
    public class OrderController : Controller
    {
        [Authorize]
        // GET: Order
        public ActionResult MyOrder()
        {
            Database db = new Database();
            var myOrder = db.Orders.MyOrder();
            return View(myOrder);
        }

        public ActionResult Orders()
        {
            Entities db = new Entities();
            var orders = db.Orders.ToList();
            return View(orders);
        }

        public ActionResult Details(int Id)
        {
            Entities db = new Entities();
            var details = (from o in db.Orders
                          where o.Id == Id
                          select o).FirstOrDefault();
            return View(details);
        }

        public ActionResult Process(int id)
        {
            Database db = new Database();
            db.Orders.StatusUpdate(id);
            return RedirectToAction("Orders");
        }

        public ActionResult Cancel(int id)
        {
            Database db = new Database();
            db.Orders.CancelOrder(id);
            return RedirectToAction("Orders");
            

        }
    }
}