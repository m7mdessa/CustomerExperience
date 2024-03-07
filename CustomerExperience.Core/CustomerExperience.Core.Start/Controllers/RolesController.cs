using Confluent.Kafka;
using CustomerExperience.Core.Application.Commands.CreateUser;
using CustomerExperience.Core.Application.Commands.Login;
using CustomerExperience.Core.Infra.Services;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polly;
using System.Text.Json;

namespace CustomerExperience.Core.Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly IMediator _mediator;

        private readonly ProducerService _producerService;

        public RolesController(IMediator mediator, ProducerService producerService)
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
        public async Task<ActionResult> CreateUser(int roleId, [FromBody] CreateUserCommand command, [FromServices] ITopicProducer<string, CreateUserCommand> producer)
        {
            command.RoleId = roleId;
            var message = JsonSerializer.Serialize(command);

            await _producerService.ProduceAsync("UserCreated", message);

            var retryPolicy = Policy
                .Handle<ProduceException<string, CreateUserCommand>>()
                .RetryAsync(3, (ex, retryCount) =>
                {
                    // Log or handle the exception on each retry if needed
                    Console.WriteLine("errrooooooooooorrrrrrrrrrrrrrrrrrrrrrrrrrrr");
                });

            var fallbackPolicy = Policy
        .Handle<ProduceException<string, CreateUserCommand>>()
        .FallbackAsync((result) =>
        {
            // Handle fallback logic here
            return Task.FromResult(StatusCode(500, "Fallback response"));
        });

            var result = await fallbackPolicy
                .WrapAsync(retryPolicy)
                .ExecuteAsync(async () =>
                {
                    await producer.Produce($"{command.CustomerId}", command);
                    return "Success";
                });

            // Use 'result' if needed (it will be "Success" or the fallback response)

            return Ok(await _mediator.Send(command));
        }

        #endregion
    }
}
