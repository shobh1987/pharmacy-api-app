using Microsoft.AspNetCore.Mvc;

namespace PharmacyApi.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    public class WelcomeController : ControllerBase
    {

        [HttpGet(Name = "welcome")]
        public async Task<IActionResult> Get()
        {
            return Ok("Welcome to Medicine Pharmacy API!");
        }
    }
}
