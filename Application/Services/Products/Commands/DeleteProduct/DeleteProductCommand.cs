

using FluentResults;
using MediatR;

namespace Application.Services.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }
}
