using CustomerExperience.Application.Commands.Customers.Feedbacks.AddFeedback;
using CustomerExperience.Application.Commands.Customers.Feedbacks.DeleteFeedback;
using CustomerExperience.Application.Commands.Customers.Feedbacks.UpdateFeedback;
using CustomerExperience.Application.Queries.Customers.Feedbacks;
using Microsoft.AspNetCore.Mvc;
using static CustomerExperience.Application.Queries.Customers.Feedbacks.GetFeedbackDetails;
using static CustomerExperience.Application.Queries.Customers.Feedbacks.GetFeedbackList;


namespace CustomerExperience.Presentation.API.Controllers.Customers
{
    public partial class CustomersController
    {
        #region Queries

        [HttpGet("{customerId}/Feedbacks")]
        public async Task<ActionResult<List<GetFeedbackListDto>>> GetFeedbacks(int customerId)
        {
            var query = new GetFeedbackListQuery(customerId);
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpGet("{customerId}/Feedback/{id}")]
        public async Task<ActionResult<GetFeedbackDetailsDto>> GetFeedback(int id,int customerId)
        {
            var query = new GetFeedbackDetailsQuery(id, customerId);
            var result = await _mediator.Send(query);

            return Ok(result);
        }



        #endregion


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
