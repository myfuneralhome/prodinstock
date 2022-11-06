using Prodinstock.Products.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Prodinstock.WebApi.Controllers
{
    public abstract class CommonController : ControllerBase
    {
        protected readonly ICurrentUserProvider CurrentUserProvider;

        protected CommonController(
            ICurrentUserProvider currentUserProvider)
        {
            CurrentUserProvider = currentUserProvider;
        }
    }
}
