using AutoMapper;
using CleanArchEcommerce.Application.Common.Mappings;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Services.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Result<Product>>, IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal PurchasePrice { get; set; }
        public int StockQuantity { get; set; }
        public bool IsAvailable { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProductCommand, Product>();
        }
    }


}
