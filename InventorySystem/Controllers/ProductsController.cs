using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Common.DTOs.Product;
using Application.Services.Products.Commands.CreateProduct;
namespace InventorySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { ProductId = id });
        }
    }
}

