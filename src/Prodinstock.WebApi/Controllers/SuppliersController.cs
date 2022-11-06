using Prodinstock.Core;
using Prodinstock.Products.Domain;
using Prodinstock.Products.Domain.Queries;
using Prodinstock.Products.Domain.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Prodinstock.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : CommonController
    {
        private readonly SupplierCreation _supplierCreation;
        private readonly IQueryHandler<ListSuppliers, ExistingSupplier[]> _listSuppliers;
        private readonly ICurrentUserProvider _currentUserProvider;

        public SuppliersController(
            IQueryHandler<ListSuppliers, ExistingSupplier[]> listSuppliers,
            SupplierCreation supplierCreation,
            ICurrentUserProvider currentUserProvider)
            : base(currentUserProvider)
        {
            _listSuppliers = listSuppliers;
            _supplierCreation = supplierCreation;
            _currentUserProvider = currentUserProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [Required] SupplierToAdd newSupplier)
        {
            var commandResult = await _supplierCreation.ExecuteAsync(
                new NewSupplier(
                    newSupplier.Name,
                    await CurrentUserProvider.Get())
                );

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

        public sealed class SupplierToAdd
        {
            [Required]
            public string Name { get; set; } = null!;
        }
    }
}
