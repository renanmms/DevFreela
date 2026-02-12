using DevFreela.Application.Commands.InsertSkill;
using DevFreela.Application.Commands.InsertUser;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.Commands.RecoverPassword;
using DevFreela.Application.Commands.ValidateRecoveryCode;
using DevFreela.Application.Queries.GetAllUsers;
using DevFreela.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);

            var result = await _mediator.Send(query);
            
            return Ok(result.Data);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(InsertUserCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPost("{id}/skills")]
        public async Task<IActionResult> PostSkills(int id, InsertSkillCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPost("{id}/profile-picture")]
        public IActionResult PostProfilePicture(IFormFile file)
        {
            var description = $"File: {file.FileName}, Size: {file.Length}";
            return Ok(description);
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost("password-recovery/request")]
        [AllowAnonymous]
        public async Task <IActionResult> RecoverPassword(RecoverPasswordCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            
            return NoContent();
        }

        [HttpPost("password-recovery/validate")]
        [AllowAnonymous]
        public async Task<IActionResult> ValidateRecoveryCode(ValidateRecoveryCodeCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPost("password-recovery/change")]
        [AllowAnonymous]
        public IActionResult ChangePassword()
        {
            return Ok();
        }
    }
}
