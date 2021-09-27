using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using labTask2.Models;
using System.Data.SqlClient;

namespace labTask2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Products()
        {
            return View();
        }
        [HttpPost]
       public ActionResult Products(Product p)
        {
            string connString = @"Server=DESKTOP-F2QN1PO\SQLEXPRESS;Database=ZOZO; Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            string query = String.Format("Insert into Products values('{0}','{1}','{2}','{3}')", p.Name, p.Price, p.Quantity, p.Discription);
            SqlCommand cmd = new SqlCommand(query,conn);
            conn.Open();
            int r= cmd.ExecuteNonQuery();
            conn.Close();
            return View();
        }
    }
}