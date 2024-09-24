using DevFreela.Application.Commands.InsertSkill;
using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        private readonly IMediator _mediator;
        public SkillsController(
            DevFreelaDbContext context,
            IMediator mediator
        )
        {
            _context = context;
            _mediator = mediator;
        }

        // TODO: Create Commands and Queries for Skills
        [HttpGet]
        public IActionResult GetAll()
        {
            var skills = _context.Skills.ToList();

            return Ok(skills);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertSkillCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }   
    }
}
