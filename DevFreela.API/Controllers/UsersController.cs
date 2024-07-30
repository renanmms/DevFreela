using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
