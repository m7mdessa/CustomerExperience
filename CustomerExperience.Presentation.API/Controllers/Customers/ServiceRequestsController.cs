using CustomerExperience.Application.Commands.Customers.ServiceRequests.AddServiceRequest;
using CustomerExperience.Application.Commands.Customers.ServiceRequests.DeleteServiceRequest;
using CustomerExperience.Application.Commands.Customers.ServiceRequests.UpdateServiceRequest;
using CustomerExperience.Application.Queries.Customers.ServiceRequests;
using Microsoft.AspNetCore.Mvc;
using static CustomerExperience.Application.Queries.Customers.ServiceRequests.GetServiceRequestDetails;
using static CustomerExperience.Application.Queries.Customers.ServiceRequests.GetServiceRequestList;


namespace CustomerExperience.Presentation.API.Controllers.Customers
{
    public partial class CustomersController
    {
        #region Queries

        [HttpGet("{customerId}/serviceRequests")]
        public async Task<ActionResult<List<GetServiceRequestListDto>>> GetServiceRequests(int customerId)
        {
            var query = new GetServiceRequestListQuery(customerId);
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpGet("{customerId}/serviceRequest/{id}")]
        public async Task<ActionResult<GetServiceRequestDetailsDto>> GetServiceRequest(int id, int customerId)
        {
            var query = new GetServiceRequestDetailsQuery(id, customerId);
            var result = await _mediator.Send(query);

            return Ok(result);
        }



        #endregion

        #region Commands


        [HttpPost("{customerId}/serviceRequest")]
        public async Task<ActionResult> CreateServiceRequest(int customerId,
            [FromBody] AddServiceRequestCommand command)
        {
            command.CustomerId = customerId;
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{customerId}/serviceRequest/{id}")]
        public async Task<ActionResult> UpdateServiceRequest(int customerId, int id,
        [FromBody] UpdateServiceRequestCommand command)
        {
            command.CustomerId = customerId;
            command.Id = id;

            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{customerId}/serviceRequest/{id}")]
        public async Task<ActionResult> DeleteServiceRequest(int customerId, int id,
            [FromBody] DeleteServiceRequestCommand command)
        {
            command.CustomerId = customerId;
            command.Id = id;

            return Ok(await _mediator.Send(command));
        }
        #endregion


    }

}
