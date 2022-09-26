using BTech.Prodinstock.Core;
using BTech.Prodinstock.Products.Domain.Queries;
using BTech.Prodinstock.Products.Domain.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BTech.Prodinstock.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {

        private readonly InvoiceCreation _invoiceCreation;

        public InvoicesController(
            InvoiceCreation invoiceCreation)
        {
            _invoiceCreation = invoiceCreation;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [Required] NewInvoice newInvoice)
        {
            var commandResult = await _invoiceCreation.ExecuteAsync(newInvoice);

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
}
