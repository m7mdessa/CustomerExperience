using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExperience.Application.Commands.Customers.Feedbacks.DeleteFeedback
{
    public class DeleteFeedbackCommand : IRequest<int>
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }



    }
}
