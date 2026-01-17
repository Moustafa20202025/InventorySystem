using Application.Common.DTOs.Product;
using Application.Services.Products.Commands.CreateProduct;
using Domain.Entities;
using Domain.Interfaces;
using FluentResults;
using MediatR;

public class AddProductHandler : IRequestHandler<AddProductCommand, Result<ProductDto>>
{
    private readonly IProductRepository _repository;

    public AddProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductDto>> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            PurchasePrice = request.PurchasePrice,
            StockQuantity = request.StockQuantity,
            IsAvailable = request.IsAvailable
        };

        await _repository.CreateProductAsync(product);

        var dto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            PurchasePrice = product.PurchasePrice,
            StockQuantity = product.StockQuantity,
            IsAvailable = product.IsAvailable
        };

        return Result.Ok(dto);
    }
}
