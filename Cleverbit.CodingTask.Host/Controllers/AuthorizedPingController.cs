using Cleverbit.CodingTask.Utilities.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cleverbit.CodingTask.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorizedPingController : ControllerBase
    {
        [HttpGet]
        public string Ping()
        {
            return "Healthy";
        }
    }
}
