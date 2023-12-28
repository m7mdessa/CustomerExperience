using MediatR;


namespace CustomerExperience.Application.Commands.Customers.Feedbacks.DeleteFeedback
{
    public class DeleteFeedbackCommand : IRequest<int>
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }



    }
}
