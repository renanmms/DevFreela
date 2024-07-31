using DevFreela.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly IConfigService _configService;
        public SkillsController(IConfigService configService)
        {
            _configService = configService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_configService.GetValue());
        }

        [HttpPost]
        public IActionResult Post()
        {
            return NoContent();
        }   
    }
}
