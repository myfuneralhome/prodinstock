using BTech.Prodinstock.Core;
using BTech.Prodinstock.Products.Domain;
using BTech.Prodinstock.Products.Domain.Queries;
using BTech.Prodinstock.Products.Domain.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BTech.Prodinstock.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : CommonController
    {
        private readonly ProductCreation _productCreation;
        private readonly IQueryHandler<ListProducts, ExistingProduct[]> _listProducts;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(
            ILogger<ProductsController> logger
            , ProductCreation productCreation
            , IQueryHandler<ListProducts, ExistingProduct[]> listProducts
            , ICurrentUserProvider currentUserProvider)
            : base(currentUserProvider)
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
                product.SupplierId,
                product.CategoryId,
                product.Name,
                product.Description,
                product.NumberInStock,
                product.SalePrice,
                product.VATRate,
                product.AccountingAccountId,
                product.BuyingPrice,
                CurrentUserProvider.Get()
                ));

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
            return await _listProducts.HandleAsync(new ListProducts());
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
        public string? SupplierId { get; set; }
        public int? AccountingAccountId { get; set; }
    }
}
