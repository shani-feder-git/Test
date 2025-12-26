using ProductManager.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManager.API.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts(string? category = null);
        Task<Product> CreateProduct(Product product);
        Task UpdateStock(int id, int newStock);
    }
}
