using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/projects")]
    [ApiController]

    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;   

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        //api/Projects/query
        [HttpGet]
        public IActionResult Get(string query)
        {
            var projects = _projectService.GetAll(query);
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);

            if(project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel createProject)
        {
            var titleLength = createProject.Title.Length;
            if(titleLength > 50)
            {
                return BadRequest();
            }

            var id = _projectService.Create(createProject);
            //var newProject = _proje
            return CreatedAtAction(nameof(GetById), new { id = id }, createProject); 
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel updateProject)
        {
            var descriptionLength = updateProject.Description.Length;
            if(descriptionLength > 50)
            {
                return BadRequest();
            }

            _projectService.Update(updateProject);
            
            return NoContent();
        }

        // api/projects/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);
            return NoContent();
        }

        // api/Projects/2/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel createComment)
        {
            _projectService.CreateComment(createComment);
            return NoContent();
        }

        // api/Projects/2/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public  IActionResult Finish(int id)
        {
            _projectService.Finish(id);
            return NoContent();
        }

    }
}
