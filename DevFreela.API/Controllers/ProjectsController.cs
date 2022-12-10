using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;

        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
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
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            var titleLength = command.Title.Length;
            if(titleLength > 50)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command); 
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] UpdateProjectCommand command)
        {
            var descriptionLength = command.Description.Length;
            if(descriptionLength > 50)
            {
                return BadRequest();
            }

            _mediator.Send(command);
            
            return NoContent();
        }

        // api/projects/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteProjectCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // api/Projects/2/comments
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            var mediator = await _mediator.Send(command);

            return NoContent();
        }

        // api/Projects/2/start
        [HttpPut("{id}/start")]
        public IActionResult Start([FromBody] StartProjectCommand command)
        {
            _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish([FromBody] FinishProjectCommand command)
        {
            _mediator.Send(command);
            return NoContent();
        }

    }
}
