using Application.Common.DTOs.Product;
using AutoMapper;
using Domain.Interfaces;
using FluentResults;
using MediatR;
using Serilog;

using static Application.Common.shared;

namespace Application.Services.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Result<List<ProductDto>>>
    {
        #region Field
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        #endregion
        #region Constructure
        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        #endregion
        #region Handling Function
   

        async Task<Result<List<ProductDto>>> IRequestHandler<GetProductQuery, Result<List<ProductDto>>>.Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAllProductAsync();
            if (product.Count() == 0)
            {
                Log.Error("Product not found.");
                return Result.Fail<List<ProductDto>>(new Error("Product not found").WithMetadata("ErrorType", ErrorType.NotFound));
            }
            var productList = _mapper.Map<List<ProductDto>>(product);
            return Result.Ok(productList);
        }
        #endregion
    }
}
