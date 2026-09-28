using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop Dell",     Price = 15000000 },
                new Product { Id = 2, Name = "Chuột Logitech",  Price = 350000 },
                new Product { Id = 3, Name = "Bàn phím cơ",     Price = 1200000 },
                new Product { Id = 4, Name = "Màn hình LG 24\"", Price = 3500000 }
            };

            return View(products);
        }
    }
}