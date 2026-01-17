

using Application.Common.DTOs.Product;
using FluentResults;
using MediatR;

namespace Application.Services.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Result<ProductDto>>
    {
        public int ProductId { get; set; }
    }
}
