using Microsoft.AspNetCore.Mvc;
using Tweetbook.Filters;

namespace Tweetbook.Controllers.V1
{
    [ApiKeyAuth]
    public class SecretController : Controller
    {
        [HttpGet("secret")]
        public IActionResult GetSecret()
        {
            return Ok("I have no secret");
        }
    }
}
