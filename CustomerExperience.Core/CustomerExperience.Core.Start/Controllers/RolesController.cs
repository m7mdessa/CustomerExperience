using CustomerExperience.Core.Application.Commands.CreateUser;
using CustomerExperience.Core.Application.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerExperience.Core.Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly IMediator _mediator;


        public RolesController(IMediator mediator)
        {
            _mediator = mediator;

        }


        #region Commands

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginCommand command)
        {

            return Ok(await _mediator.Send(command));

        }


        [HttpPost("{roleId}/user")]
        public async Task<ActionResult> CreateUser(int roleId, [FromBody] CreateUserCommand command)
        {
            command.RoleId = roleId;

            return Ok(await _mediator.Send(command));

        }

      
        #endregion
    }
}
