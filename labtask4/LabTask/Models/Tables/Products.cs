using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LabTask.Models.Tables
{
    public class Products
    {
        SqlConnection conn;

        public Products(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void AddProduct(Product p)
        {
            string query = string.Format("insert into Products values('{0}','{1}','{2}','{3}')",p.ProductName,p.Price,p.Quantity.ToString(),p.Description);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Product GetProductById(int id)
        {
            string query = "select *  from Products where Id="+id;
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Product p = new Product();
            if (reader.Read())
            {

                p.Id = reader.GetInt32(reader.GetOrdinal("id"));
                p.ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
                p.Price = (float)reader.GetDouble(reader.GetOrdinal("Price"));
                p.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                p.Description = reader.GetString(reader.GetOrdinal("Description"));
                
            }
            conn.Close();
            return p;
        }

        public List<Product> GetAllProducts()
        {
            string query ="select * from Products";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product p = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                    Price = (float)reader.GetDouble(reader.GetOrdinal("Price")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                };
                products.Add(p);
            }
            conn.Close();
            return products;
        }

        public void UpdateProduct(Product p,int id)
        {
            string query = "UPDATE Products SET ProductName='" + p.ProductName + "',Quantity='" + p.Quantity + "',Price='" + p.Price + "' WHERE Id=" + id;
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void deleteProduct(int id)
        {
            string query = "Delete from Products where Id=" + id;
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}