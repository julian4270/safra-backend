using Safrasas.Api.Filter;
using Microsoft.AspNetCore.Mvc;

namespace Safrasas.Api.Controllers
{
    [Route("api/[controller]")]
    [TypeFilter(typeof(AuthorizationFilterAttribute))]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}