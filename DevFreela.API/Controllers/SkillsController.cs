using DevFreela.Application.Commands.InsertSkill;
using DevFreela.Application.Models;
using DevFreela.Application.Queries.GetAllSkills;
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

        [HttpGet]
        public IActionResult GetAll()
        {
            var query = new GetAllSkillsQuery();
            var result = _mediator.Send(query);

            return Ok(result);
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
