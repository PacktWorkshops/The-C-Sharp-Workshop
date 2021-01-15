using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Chapter06.Examples._01_Talking_With_Db_The_Old_Way
{
    public class GetAllProductsQueryHandler
    {
        public IEnumerable<Product> GetAllProducts()
        {
            var connection = new SqlConnection(Program.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Factory.Product", connection);
            var reader = command.ExecuteReader();
            var products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader["Id"],
                    ManufacturerId = (int)reader["ManufacturerId"],
                    Name = (string)reader["Name"],
                    Price = (decimal)reader["Price"]
                }); 
            }

            return products;
        }
    }
}
