using AutoMapper;
using CleanArchEcommerce.Application.Common.Mappings;
using Domain.Entities;

namespace Application.Common.DTOs.Product
{
    public class ProductDto : IMapFrom<Domain.Entities.Product>
    {
        public ProductDto() { } // لازم يكون موجود

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PurchasePrice { get; set; }
        public int StockQuantity { get; set; }
        public bool IsAvailable { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Product, ProductDto>();
            profile.CreateMap<ProductDto, Domain.Entities.Product>();
        }
    }
}
