using BTech.Prodinstock.Products.Domain.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BTech.Prodinstock.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly SupplierCreation _supplierCreation;

        public SuppliersController(
            SupplierCreation supplierCreation)
        {
            _supplierCreation = supplierCreation;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [Required] NewSupplier newSupplier)
        {
            var commandResult = await _supplierCreation.ExecuteAsync(newSupplier);

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