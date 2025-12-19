using Application.Services.Products.Commands.CreateProduct;
using Application.Services.Products.Commands.DeleteProduct;
using Application.Services.Products.Commands.UpdateProduct;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Common.shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
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
        #region /Put /UpdateProduct

        [HttpPut("{id}")]
        
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                if (result.IsFailed)
                {
                    return BadRequest(new
                    {
                        message = "Update failed",
                        errors = result.Errors.Select(e => e.Message)
                    });
                }

                return Ok(new
                {
                    message = "Product updated successfully",
                    product = result.Value
                });
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(new
                {
                    message = "Validation error",
                    errors = ex.Errors.Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error",
                    error = ex.Message
                });
            }
        }

        #endregion
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand delete , int id)
        {
             var result = await _mediator.Send(delete);

            if (delete.Id == 0)
                return NotFound(new { error = ErrorType.NotFound.ToString() });

            return Ok(new { message = "Deleted", error = ErrorType.succseeded.ToString() });
        }

    }
}

