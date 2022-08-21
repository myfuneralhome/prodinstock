using BTech.Prodinstock.Products.Domain.Queries;
using BTech.Prodinstock.Products.Domain.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BTech.Prodinstock.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryCreation _categoryCreation;

        private readonly IQueryHandler<ListCategoriesWithProductCount, ExistingCategory[]> _listCategoriesWithProductCount;

        public CategoriesController(
            IQueryHandler<ListCategoriesWithProductCount, ExistingCategory[]> listCategoriesWithProductCount
            , CategoryCreation categoryCreation)
        {
            _listCategoriesWithProductCount = listCategoriesWithProductCount;
            _categoryCreation = categoryCreation;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [Required] NewCategory newCategory)
        {
            var commandResult = await _categoryCreation.ExecuteAsync(newCategory);

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
        public async Task<ExistingCategory[]> List()
        {
            return await _listCategoriesWithProductCount.HandleAsync(new ListCategoriesWithProductCount());
        }
    }
}