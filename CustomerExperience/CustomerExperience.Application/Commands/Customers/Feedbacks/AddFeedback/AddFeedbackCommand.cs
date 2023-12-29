using MediatR;


namespace CustomerExperience.Application.Commands.Customers.Feedbacks.AddFeedback
{
  
    public class AddFeedbackCommand : IRequest<int>
    {
        public int CustomerId { get;  set; }
        public DateTime FeedbackDate { get;  set; }
        public string FeedbackText { get;  set; }


    }
}
