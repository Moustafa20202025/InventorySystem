using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentResults;
using MediatR;

namespace Application.Services.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<Product>>
    {
        #region Fields
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        #endregion

        #region Handling function
        public async Task<Result<Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(request.Id);
            if (existingProduct is null)
                return Result.Fail<Product>($"Product with Id {request.Id} not found.");

            _mapper.Map(request, existingProduct);

            var result = await _productRepository.UpdateAsync(request.Id,existingProduct);

            if (result.IsFailed)
                return Result.Fail<Product>("Update failed, no rows affected.");

            return Result.Ok(existingProduct);
        }
        #endregion
    }
}
