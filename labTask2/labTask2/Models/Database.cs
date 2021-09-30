using labTask2.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace labTask2.Models
{
    public class Database
    {
        public Products Products { get; set; }

        public Database()
        {
            string connString = @"Server=DESKTOP-F2QN1PO\SQLEXPRESS;Database=ZOZO;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            Products = new Products(conn);
        }

    }
}