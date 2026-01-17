

using Application.Common.DTOs.Product;
using FluentResults;
using MediatR;

namespace Application.Services.Products.Queries.GetProduct
{
  
    
        public class GetProductQuery : IRequest<Result<List<ProductDto>>>
        {
            public int PageNumger { get; set; }
            public int PageSize { get; set; } = 10;
        }
    
}
