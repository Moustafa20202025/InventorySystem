using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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




//


//public virtual ICollection<Item> Items { get; set; } = new List<Item>();
//public Product() { }
//public void UpdateProductQuantity(int quantity)
//{
//    StockQuantity = StockQuantity - quantity;
//}
//public void UpdateProductAvaible(int quantity, string isAvailable)
//{
//    StockQuantity = StockQuantity - quantity;
//    IsAvailable = isAvailable;
//}