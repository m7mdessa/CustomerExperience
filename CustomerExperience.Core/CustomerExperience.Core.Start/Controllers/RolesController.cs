using CustomerExperience.Core.Application.Commands.CreateUser;
using CustomerExperience.Core.Application.Commands.Login;
using CustomerExperience.Core.Infra.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CustomerExperience.Core.Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly IMediator _mediator;

        private readonly ProducerService _producerService;

        public RolesController(IMediator mediator , ProducerService producerService)
        {
            _mediator = mediator;
            _producerService = producerService;

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
            var message = JsonSerializer.Serialize(command);

            await _producerService.ProduceAsync("UserCreated", message);

           
            return Ok(await _mediator.Send(command));

        }

      
        #endregion
    }
}
