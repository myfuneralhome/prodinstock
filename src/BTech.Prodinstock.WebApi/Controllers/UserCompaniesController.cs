using BTech.Prodinstock.Products.Domain.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BTech.Prodinstock.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserCompaniesController : ControllerBase
    {
        private readonly UserCompanyCreation _userCompanyCreation;

        public UserCompaniesController(
            UserCompanyCreation userCompanyCreation)
        {
            _userCompanyCreation = userCompanyCreation;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
                    [Required] UserCompanyToAdd userCompanyToAdd)
        {
            var commandResult = await _userCompanyCreation.ExecuteAsync(
                new NewCompany(
                    userCompanyToAdd.LegalName)
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
    }

    public sealed class UserCompanyToAdd
    {
        [Required]
        public string LegalName { get; set; } = null!;
    }
}
