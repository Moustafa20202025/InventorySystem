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
    public class AddProductHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly IProductRepository _repository;

        public AddProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price
            };

            return await _repository.AddAsync(product);
        }
    }
}
