namespace Application.Common.DTOs.Product
{
    public record ProductDto(
        int Id,
        string Name,
        string Description,
        decimal PurchasePrice,
        int StockQuantity,
        bool IsAvailable
    );
}
