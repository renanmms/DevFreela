using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserQuery(id);
            var user = await _mediator.Send(query);

            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            if(!ModelState.IsValid){
                var messages = ModelState
                    .SelectMany(ms => ms.Value?.Errors!)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                
                return BadRequest(messages);
            }

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new {id = id}, new {id = id, user = command});
        }


        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var login = await _mediator.Send(command);
            if(login == null)
                return BadRequest();

            return Ok(login);
        }

    }
}
