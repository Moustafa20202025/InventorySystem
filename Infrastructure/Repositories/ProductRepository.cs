using Domain.Entities;
using Domain.Interfaces;
using FluentResults;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task <Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return 0;

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }


        public Task<List<Product>> GetAllProductAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Result<Product>> UpdateAsync(int id, Product product)
        {
            var existing = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (existing == null)
            {
                return Result.Fail<Product>($"Product with ID {id} not found.");
            }

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.PurchasePrice = product.PurchasePrice;
            existing.StockQuantity = product.StockQuantity;
            existing.IsAvailable = product.IsAvailable;

            await _context.SaveChangesAsync();

            return Result.Ok(existing); 
        }




       


    }
}
