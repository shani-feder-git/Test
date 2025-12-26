using ProductManager.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManager.API.Services
{
    public class MockProductService : IProductService
    {
        private List<Product> _products = new List<Product>();

        public MockProductService()
        {
            for (int i = 1; i <= 50; i++)
            {
                _products.Add(new Product
                {
                    Id = i,
                    Name = $"Product {i}",
                    Category = i % 4 == 0 ? "Electronics" : i % 4 == 1 ? "Clothing" : i % 4 == 2 ? "Food" : "Books",
                    Price = 10 + i * 2,
                    Stock = 50 + i
                });
            }
        }

        public async Task<List<Product>> GetProducts(string? category = null)
        {
            //await Task.Delay(50); 
            return string.IsNullOrEmpty(category) ? _products : _products.Where(p => p.Category.Contains(category)).ToList();
        }

        public async Task<Product> CreateProduct(Product product)
        {
            //await Task.Delay(50);
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
            return product;
        }

        public async Task UpdateStock(int id, int newStock)
        {
            //await Task.Delay(50);
            var p = _products.FirstOrDefault(p => p.Id == id);
            if (p != null) p.Stock = newStock;
        }
    }
}
