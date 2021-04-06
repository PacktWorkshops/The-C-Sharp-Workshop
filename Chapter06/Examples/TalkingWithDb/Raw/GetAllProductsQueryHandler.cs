using System.Collections.Generic;
using System.Data.SqlClient;
using Chapter06.Examples.Custom;
using Npgsql;

namespace Chapter06.Examples.TalkingWithDb.Raw
{
    public class GetAllProductsQueryHandler
    {
        public IEnumerable<Product> GetAllProducts()
        {
            using var connection = new NpgsqlConnection(Program.GlobalFactoryConnectionString);
            connection.Open(); 
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM factory.product", connection);
            var reader = command.ExecuteReader();
            var products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader["id"],
                    //ManufacturerId = (int)reader["ManufacturerId"],
                    Name = (string)reader["name"],
                    Price = (decimal)reader["price"]
                });
            }

            return products;
        }
    }
}
