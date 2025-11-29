using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;

namespace Application.Products.Commands
{
    public class ProductDTO() 
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal PurchasePrice { get; set; }

        public int StockQuantity { get; set; }

        public bool IsAvailable { get; set; } = false!;
    }
}
