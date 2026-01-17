using Application.Common.DTOs.Product;
using AutoMapper;
using Domain.Interfaces;
using FluentResults;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Common.shared;

namespace Application.Services.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductDto>>
    {
        #region Field
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        #endregion
        #region Constructure
        public GetProductByIdQueryHandler(IProductRepository productRepository,  IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        #endregion
        #region Handling function
       

       async Task<Result<ProductDto>> IRequestHandler<GetProductByIdQuery, Result<ProductDto>>.Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.ProductId);
            if (product == null)
            {
                Log.Error("No product found");
                return Result.Fail<ProductDto>("No product found");

            }
            var productResult = _mapper.Map<ProductDto>(product);
            return Result.Ok(productResult);
        }
        #endregion
    }
}
