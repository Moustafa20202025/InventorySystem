using Application.Common.DTOs.Product;
using Domain.Entities;
using FluentResults;
using MediatR;
using AutoMapper;
using CleanArchEcommerce.Application.Common.Mappings;



namespace Application.Services.Products.Commands.CreateProduct
{
    public class AddProductCommand : IRequest<Result<ProductDto>>, IMapFrom<Product>
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal PurchasePrice { get; set; }

        public int StockQuantity { get; set; }

        public bool IsAvailable { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddProductCommand, Product>();
        }
    }
}