using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExperience.Application.Commands.Customers.Feedbacks.AddFeedback
{
  
    public class AddFeedbackCommand : IRequest<int>
    {
        public int CustomerId { get;  set; }
        public DateTime FeedbackDate { get;  set; }
        public string FeedbackText { get;  set; }


    }
}
