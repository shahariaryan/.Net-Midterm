using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using work3_ORM.Models;

namespace work3_ORM.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            using (ZOZOEntities1 db = new ZOZOEntities1())
            {
                var shops = db.Shops.ToList();
                return View(shops);
            }
        }
    }
}