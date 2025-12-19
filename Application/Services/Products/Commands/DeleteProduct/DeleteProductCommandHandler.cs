

using Domain.Interfaces;
using FluentResults;
using MediatR;
using Serilog;
using static Application.Common.shared;

namespace Application.Services.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<int>>
    {
        #region Field
        private readonly IProductRepository _productRepository;
        #endregion

        #region Constructor
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Handling function
        public async Task<Result<int>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);
            if (product == null)
            {
                return Result.Fail<int>(new Error("Product not found")
                    .WithMetadata("ErrorType", ErrorType.NotFound));
            }

            var productResult = await _productRepository.DeleteProductAsync(request.Id);
            if (productResult == 0)
            {
                return Result.Fail<int>(new Error("Something went wrong while deleting product")
                    .WithMetadata("ErrorType", ErrorType.BadRequest));
            }

            Log.Information($"Product ID: {request.Id} deleted successfully.");
            return Result.Ok(productResult);
        }
        #endregion
    }



}

