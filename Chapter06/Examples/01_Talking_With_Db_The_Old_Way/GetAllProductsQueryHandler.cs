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
            var connection = new SqlConnection("");
            return null;
        }
    }
}
