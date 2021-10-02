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

        public Product Get(int Id)
        {
            string query = String.Format("select * from Products where Id={0}", Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Product products = new Product();
            products.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            products.Name = reader.GetString(reader.GetOrdinal("Name"));
            products.Price = reader.GetString(reader.GetOrdinal("Price"));
            products.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));
            products.Description = reader.GetString(reader.GetOrdinal("Description"));

            conn.Close();
            return products;
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

        internal object GetOneProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Product p)
        {
            string query = String.Format("update Products set Name='{0}',Price='{1}',Quantity='{2}',Description='{3}' where Id ={4}", p.Name, p.Price, p.Quantity,
                p.Description, p.Id);
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