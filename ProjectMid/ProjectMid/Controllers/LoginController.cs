using ProjectMid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectMid.Controllers
{
    public class LoginController : Controller
    {
        
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(User m, string Uid, string Password)
        {
            if (ModelState.IsValid)
            {
                ProjectEntities db = new ProjectEntities();

                var user = db.Users.FirstOrDefault(e => e.Uid == m.Uid);
                if (user != null)
                {
                    var password = db.Users.FirstOrDefault(e => e.Password == m.Password);
                    if (password != null)
                    {
                        FormsAuthentication.SetAuthCookie(m.Uid, true);
                        return RedirectToAction("Index", "Student");
                     }
                    else
                    {
                        TempData["ErrorMessage"] = "Incorrect Username/Password";
                        return View();
                    }
                }

            }
            else
            {
                TempData["ErrorMessage"] = "This email doesn't exist";
                return View();

            }
            return View();
        }
        
    } 

}

   
