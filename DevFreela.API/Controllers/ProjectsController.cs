using DevFreela.Application.Commands.CompleteProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.InsertComment;
using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Models;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _service;
        private readonly IMediator _mediator;
        public ProjectsController(IProjectService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        // GET api/projects?search=crm
        [HttpGet]
        public async Task<IActionResult> Get(string searchs = "", int page = 0, int size = 3)
        {
            var query = new GetAllProjectsQuery();
            var result = await _mediator.Send(query);
            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var query = new GetProjectByIdQuery(id);
            var result = await _mediator.Send(query);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            
            return Ok(result.Data);
        }


        [HttpPost]
        public async Task<IActionResult> Post(InsertProjectCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data}, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProjectInputModel model)
        {
            var command = new UpdateProjectCommand(model.IdProject, model.Title, model.Description, model.TotalCost);
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);
            var result = await _mediator.Send(command);

           if(!result.IsSuccess)
           {
                return BadRequest(result.Message);
           }

            return NoContent();
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var command = new CompleteProjectCommand(id);
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(CreateProjectCommentInputModel model)
        {
            var command = new InsertCommentCommand(model.Content, model.IdProject, model.IdUser);
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

    }
}
