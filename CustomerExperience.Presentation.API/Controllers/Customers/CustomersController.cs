using CustomerExperience.Application.Commands.Customers.CreateCustomer;
using CustomerExperience.Application.Commands.Customers.UpdateCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerExperience.Presentation.API.Controllers.Customers
{
    [Route("api/[controller]")]
    [ApiController]

    public partial class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;


        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;

        }

        #region Commands

        [HttpPost("CreateCustomer")]
        public async Task<ActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {

            return Ok(await _mediator.Send(command));

        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(int id,
            [FromBody] UpdateCustomerCommand command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }


        #endregion



    }
}
