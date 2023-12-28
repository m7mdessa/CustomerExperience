using CustomerExperience.Application.Commands.Customers.Feedbacks.AddFeedback;
using CustomerExperience.Application.Commands.Customers.Feedbacks.DeleteFeedback;
using CustomerExperience.Application.Commands.Customers.Feedbacks.UpdateFeedback;
using Microsoft.AspNetCore.Mvc;


namespace CustomerExperience.Presentation.API.Controllers.Customers
{
    public partial class CustomersController
    {
        #region Commands

     
        [HttpPost("{customerId}/feedBacks")]
        public async Task<ActionResult> CreateFeedback(int customerId,
            [FromBody] AddFeedbackCommand command)
        {
            command.CustomerId = customerId;
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{customerId}/feedBacks/{id}")]
        public async Task<ActionResult> UpdateFeedback(int customerId, int id,
        [FromBody] UpdateFeedbackCommand command)
        {
            command.CustomerId = customerId;
            command.Id = id;

            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{customerId}/feedBacks/{id}")]
        public async Task<ActionResult> DeleteFeedback(int customerId, int id,
            [FromBody] DeleteFeedbackCommand command)
        {
            command.CustomerId = customerId;
            command.Id = id;

            return Ok(await _mediator.Send(command));
        }
        #endregion


    }
}
