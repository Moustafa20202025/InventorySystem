using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands
{
    public record AddProductCommand(
          string Name,
          string Description,
          decimal PurchasePrice,
          int StockQuantity,
          bool IsAvailable
      ) : IRequest<int>;
}
