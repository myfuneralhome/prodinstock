using BTech.Prodinstock.Core;
using BTech.Prodinstock.Products.Domain.Queries;
using BTech.Prodinstock.Products.Domain.UseCases.OrderProducts;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BTech.Prodinstock.WebApi.Controllers
{

    [ApiController]
    [Route("api/invoices/{invoiceId}/order-products")]
    public class OrderProductController : ControllerBase
    {
        private readonly OrderProductCreation _orderProductCreation;
        private readonly IQueryHandler<ListOrderProducts, ExistingOrderProduct[]> _listOrderProducts;

        public OrderProductController(
            OrderProductCreation orderProductCreation,
            IQueryHandler<ListOrderProducts, ExistingOrderProduct[]> listOrderProducts)
        {
            _orderProductCreation = orderProductCreation;
            _listOrderProducts = listOrderProducts;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [Required] string invoiceId,
            [Required] OrderProductToCreate newOrderProduct)
        {
            var commandResult = await _orderProductCreation.ExecuteAsync(
                new NewOrderProduct(
                    invoiceId,
                    newOrderProduct.ProductId,
                    newOrderProduct.ProductName,
                    newOrderProduct.Price,
                    newOrderProduct.Quantity));

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
        public async Task<ExistingOrderProduct[]> List(string invoiceId)
        {
            return await _listOrderProducts.HandleAsync(new ListOrderProducts() {  InvoiceId = invoiceId });
        }
    }

    public sealed class OrderProductToCreate
    {
        [Required]
        public string ProductId { get; set; } = null!;

        [Required]
        public string ProductName { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
