using Application.Queries.Users;
using CustomerExperience.Application.Commands.Customers.CreateCustomer;
using CustomerExperience.Application.Commands.Customers.UpdateCustomer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Application.Queries.Users.GetCustomerDetails;
using static Application.Queries.Users.GetCustomerList;

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

        #region Queries

        [HttpGet("Customers")]
        public async Task<ActionResult<List<GetCustomerListDto>>> GetCustomer()
        {
            var query = new GetCustomerListQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpGet("{id}/Customer")]
        public async Task<ActionResult<GetCustomerDetailsDto>> GetCustomer(int id)
        {
            var query = new GetCustomerDetailsQuery(id);
            var result = await _mediator.Send(query);

            return Ok(result);
        }



        #endregion



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
