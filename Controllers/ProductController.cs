using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using lesson5.Models;

namespace lesson5.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration _config;

        public ProductController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            var products = new List<Product>();
            string connStr = _config.GetConnectionString("DefaultConnection")!;

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT Id, Name, Price FROM Product";

                using (var cmd = new SqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2)
                        });
                    }
                }
            }

            return View(products);
        }
    }
}