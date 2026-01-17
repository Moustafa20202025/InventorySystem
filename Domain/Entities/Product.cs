

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }     
        public string? Name { get; set; } 
        public decimal Price { get; set; }
        public string Description { get;  set; } = null!;
        public decimal PurchasePrice { get;  set; }

        public int StockQuantity { get;  set; }

        public bool IsAvailable { get;  set; } = false!;

    }
}




