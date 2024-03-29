﻿using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProject;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]

    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //api/Projects/query
        [HttpGet]
        [Authorize(Roles = "client,freelancer")]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProjectsQuery = new GetAllProjectsQuery(query);
            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "client,freelancer")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProjectQuery(id);
            var project = await _mediator.Send(query);

            if(project == null)
                return NotFound();
            
            return Ok(project);
        }

        [HttpPost]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command); 
        }

        [HttpPut]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            await _mediator.Send(command);
            
            return NoContent();
        }

        // api/projects/3
        [HttpDelete("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Delete([FromBody] DeleteProjectCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // api/Projects/2/comments
        [HttpPost("{id}/comments")]
        [Authorize(Roles = "client,freelancer")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            var mediator = await _mediator.Send(command);

            return NoContent();
        }

        // api/Projects/2/start
        [HttpPut("{id}/start")]
        [Authorize(Roles = "freelancer")]
        public async Task<IActionResult> Start([FromBody] StartProjectCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        [Authorize(Roles = "freelancer")]
        public async Task<IActionResult> Finish([FromBody] FinishProjectCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result)
                return BadRequest("O pagamento não pôde ser processado.");
                
            return Accepted();
        }

    }
}
