using Application.Products.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Handlers
{
    public class AddProductHandler 
    {
        private readonly IProductRepository _repository;

        public AddProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(ProductDTO request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                PurchasePrice = request.PurchasePrice,
                StockQuantity = request.StockQuantity,  
                IsAvailable = request.IsAvailable   
            };

            return await _repository.CreateProductAsync(product);
        }
    }
}
