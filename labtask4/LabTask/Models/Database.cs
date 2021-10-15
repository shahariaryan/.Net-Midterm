using LabTask.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LabTask.Models
{
    public class Database
    {
        public Products Products { get; set; }
        public Orders Orders { get; set; }
        public Users Users { get; set; }
        public Database()
        {
            string connString = @"Server=DESKTOP-F2QN1PO\SQLEXPRESS;Database=ZZZ;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            Products = new Products(conn);
            Orders = new Orders(conn);
            Users = new Users(conn);
        }
    }
}