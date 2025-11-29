using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductAsync(int pageNumber, int pageSize);
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<int> UpdateProductAsync(int id, Product product);
     
        Task<int> DeleteProductAsync(int id);
    }
}

//Task<List<Product>> GetAllProductFilterAsync(string? Name, decimal? PurchasePriceMin, decimal? PurchasePriceMax, string? OrderBy, int pageNumber, int pageSize);
