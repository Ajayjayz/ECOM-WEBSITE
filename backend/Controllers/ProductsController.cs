using Microsoft.AspNetCore.Mvc;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> _products = new()
{
    new() { Id = 1, Name = "Laptop", Category = "Electronics", Price = 750, ImageUrl = "https://localhost:7400/images/laptop.jpg" },
    new() { Id = 2, Name = "Smartphone", Category = "Electronics", Price = 500, ImageUrl = "https://localhost:7400/images/mobile.jpg" },
    new() { Id = 3, Name = "Bluetooth Speaker", Category = "Electronics", Price = 150, ImageUrl = "https://localhost:7400/images/speaker.jpg" },
    new() { Id = 4, Name = "T-shirt", Category = "Clothing", Price = 25, ImageUrl = "https://localhost:7400/images/tshirt.jpg" },
    new() { Id = 5, Name = "Jeans", Category = "Clothing", Price = 60, ImageUrl = "https://localhost:7400/images/jeans.jpg" },
    new() { Id = 6, Name = "Sneakers", Category = "Footwear", Price = 110, ImageUrl = "https://localhost:7400/images/shoes.png" },
    new() { Id = 7, Name = "Notebook", Category = "Stationery", Price = 10, ImageUrl = "https://localhost:7400/images/book.jpg" },
    new() { Id = 8, Name = "Backpack", Category = "Accessories", Price = 90, ImageUrl = "https://localhost:7400/images/bag.webp" },
    new() { Id = 9, Name = "Desk Lamp", Category = "Home Decor", Price = 45, ImageUrl = "https://localhost:7400/images/lamp.jpg" },
    new() { Id = 10, Name = "Watch", Category = "Accessories", Price = 250, ImageUrl = "https://localhost:7400/images/watch.jpg" },
    new() { Id = 11, Name = "Sunglasses", Category = "Accessories", Price = 180, ImageUrl = "https://localhost:7400/images/glass.jpg" },
    new() { Id = 12, Name = "Bookshelf", Category = "Furniture", Price = 300, ImageUrl = "https://localhost:7400/images/shelf.jpg" },
};


        [HttpGet]
        public IActionResult Get(
            [FromQuery] string? search,
            [FromQuery] string? category,
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 5)
        {
            var query = _products.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));

            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);

            var total = query.Count();
            var products = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(new { total, products });
        }
    }
}
