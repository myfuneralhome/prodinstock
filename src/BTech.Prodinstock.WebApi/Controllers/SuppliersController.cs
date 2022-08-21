using BTech.Prodinstock.Core;
using BTech.Prodinstock.Products.Domain.Queries;
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
        private readonly IQueryHandler<ListSuppliers, ExistingSupplier[]> _listSuppliers;

        public SuppliersController(
            IQueryHandler<ListSuppliers, ExistingSupplier[]> listSuppliers,
            SupplierCreation supplierCreation)
        {
            _listSuppliers = listSuppliers;
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

        [HttpGet]
        public async Task<ExistingSupplier[]> List()
        {
            return await _listSuppliers.HandleAsync(new ListSuppliers());
        }
    }
}