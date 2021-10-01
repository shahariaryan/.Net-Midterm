using labTask2.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace labTask2.Models.Tables
{
    public class Products
    {

        SqlConnection conn;

        public Products(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void Add(Product p)
        {
            string query = String.Format("Insert into Products values ('{0}','{1}','{2}','{3}')", p.Name, p.Price, p.Quantity, p.Description);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();

        }

        public Product Get(int id)
        {
            return null;
        }

        public List<Product> GetAll()
        {
            string query = "Select * from Products";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product p = new Product()
                {

                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Price = reader.GetString(reader.GetOrdinal("Price")),
                    Quantity = reader.GetString(reader.GetOrdinal("Quantity")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))

                };

                products.Add(p);
            }

            conn.Close();
            return products;
        }

        public void Edit(int Id, string Name, string Price, string Quantity, string Description)
        {
            string query = String.Format("UPDATE Products set ('{0}','{1}','{2}','{3}') where '{4}'", Name,Price, Quantity, Description,Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();


        }

        public void Delete(int Id)
        {
            string query = String.Format("Delete from Products where Id={0}", Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
           

        }
        
    }
}