using BTech.Prodinstock.Products.Domain.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BTech.Prodinstock.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ProductCreation _productCreation;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(
            ILogger<ProductsController> logger
            , ProductCreation productCreation)
        {
            _logger = logger;
            _productCreation = productCreation;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [Required] Product product)
        {
            var commandResult = await _productCreation.ExecuteAsync(new NewProduct(
                product.Name,
                product.Description,
                product.NumberInStock,
                product.SalePrice,
                product.VATRate,
                product.BuyingPrice));

            if (commandResult.IsFullSuccess())
            {
                return Ok();
            }
            else
            {
                return BadRequest(commandResult.Errors);
            }
        }
    }

    public sealed class Product
    {
        [Required]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public short NumberInStock { get; set; } = 0;

        [Required]
        public decimal SalePrice { get; set; }
        public decimal VATRate { get; set; } = 0;
        public decimal BuyingPrice { get; set; } = 0;
    }
}