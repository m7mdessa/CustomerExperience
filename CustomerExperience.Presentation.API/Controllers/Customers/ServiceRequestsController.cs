using CustomerExperience.Application.Commands.Customers.ServiceRequests.AddServiceRequest;
using CustomerExperience.Application.Commands.Customers.ServiceRequests.DeleteServiceRequest;
using CustomerExperience.Application.Commands.Customers.ServiceRequests.UpdateServiceRequest;
using Microsoft.AspNetCore.Mvc;


namespace CustomerExperience.Presentation.API.Controllers.Customers
{
    public partial class CustomersController
    {


        #region Commands


        [HttpPost("{customerId}/serviceRequests")]
        public async Task<ActionResult> CreateServiceRequest(int customerId,
            [FromBody] AddServiceRequestCommand command)
        {
            command.CustomerId = customerId;
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{customerId}/serviceRequests/{id}")]
        public async Task<ActionResult> UpdateServiceRequest(int customerId, int id,
        [FromBody] UpdateServiceRequestCommand command)
        {
            command.CustomerId = customerId;
            command.Id = id;

            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{customerId}/serviceRequests/{id}")]
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
