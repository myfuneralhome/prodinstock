using BTech.Prodinstock.Products.Domain.Queries;
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
        private readonly ListProducts _listProducts;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(
            ILogger<ProductsController> logger
            , ProductCreation productCreation
            , ListProducts listProducts)
        {
            _logger = logger;
            _productCreation = productCreation;
            _listProducts = listProducts;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [Required] Product product)
        {
            var commandResult = await _productCreation.ExecuteAsync(new NewProduct(
                product.CategoryId,
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

        [HttpGet]
        public async Task<IEnumerable<ExistingProduct>> List()
        {
            return await _listProducts.ExecuteAsync();
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
        public string? CategoryId { get; set; }
    }
}