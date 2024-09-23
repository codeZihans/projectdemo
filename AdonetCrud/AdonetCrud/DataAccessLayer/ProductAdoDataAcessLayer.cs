using AdonetCrud.Models;
using Microsoft.Data.SqlClient;
using System.Globalization;


namespace AdonetCrud.DataAccessLayer
{
    public class ProductAdoDataAcessLayer : AppAdoBase
    {
        public bool Create(Product product)
        {
            //Creating INSERT query
            string query = $@"INSERT INTO Products(name,expirydate,price,unit) 
                VALUES('{product.Name}','{product.ExpiryDate.ToString("yyyy-MM-dd HH:mm:ss")}','{product.Price}','{product.Unit}');";
            //Sending query to Execute
            int rawAffected = ExecuteSql(query);
            
            if (rawAffected > 0)
            {
                return true;
            }

            return false;

        }

        public bool Update(Product product)
        {
            //Creating UPDATE query
            string query = $@"UPDATE Products SET name ='{product.Name}',expirydate ='{product.ExpiryDate.ToString("yyyy-MM-dd HH:mm:ss")}',price ='{product.Price}',unit ='{product.Unit}' WHERE id ='{product.Id}'";
            //Sending query to Execute
            int rawAffected = ExecuteSql(query);
            if (rawAffected > 0)
            {
                return true;
            }
            return false;
        }
        public Product GetProductById(int id)
        {
          
         SqlConnection connection = OpenConnection();

         string sql = $@"SELECT * FROM Products where Id = '{id}'";

         SqlCommand command = new SqlCommand();
         
         command.CommandText = sql;
         command.Connection = connection;
         SqlDataReader reader = command.ExecuteReader();

         Product product = new Product();
         //Reading entity 
         reader.Read();
         product.Id = Convert.ToInt32(reader["id"]);
         product.Name = reader["name"].ToString();
         product.ExpiryDate = Convert.ToDateTime(reader["expirydate"]);
         product.Price = Convert.ToDouble(reader["price"]);
         product.Unit = reader["unit"].ToString();
         return product;

        }

        public bool DeleteById(int id)
        {  
            //Creating DELETE query
            string query = $@"DELETE From Products where id = '{id}'";
            
            int rawAffected = ExecuteSql(query);
            if (rawAffected > 0)
            {
                return true;
            }
            return false;
        }

        public List<Product> GetProducts()
        {

            SqlConnection connection = OpenConnection();

            string sql = "SELECT * FROM Products";
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = sql;

            SqlDataReader reader = command.ExecuteReader();

            List<Product> products = new List<Product>();

            //Reading entity by entity
            while (reader.Read())
            {
                Product product = new Product();
                product.Id = Convert.ToInt32(reader["id"]);
                product.Name = reader["name"].ToString()!;
                product.ExpiryDate = Convert.ToDateTime(reader["expirydate"]);
                product.Price = Convert.ToDouble(reader["price"]);
                product.Unit = reader["unit"].ToString()!;

                products.Add(product);
            }

            reader.Close();
            Connection.Close();

            return products;

        }
     


    }
}
