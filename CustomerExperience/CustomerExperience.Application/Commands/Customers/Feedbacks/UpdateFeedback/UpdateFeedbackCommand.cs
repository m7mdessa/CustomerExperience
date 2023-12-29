

using MediatR;

namespace CustomerExperience.Application.Commands.Customers.Feedbacks.UpdateFeedback
{
 
    public class UpdateFeedbackCommand : IRequest<int>
    {
        public int Id { get; set; }

        public int CustomerId { get;  set; }
        public DateTime FeedbackDate { get;  set; }
        public string FeedbackText { get;  set; }


    }
}
