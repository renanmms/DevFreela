using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        // GET api/projects?search=crm
        [HttpGet]
        public IActionResult Get(string searchs)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            return Ok();
        }


        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1}, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProjectInputModel model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(CreateProjectCommentInputModel model)
        {
            return NoContent();
        }

    }
}
