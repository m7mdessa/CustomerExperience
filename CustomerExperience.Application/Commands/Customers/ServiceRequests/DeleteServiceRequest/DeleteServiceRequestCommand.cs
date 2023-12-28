using MediatR;

namespace CustomerExperience.Application.Commands.Customers.ServiceRequests.DeleteServiceRequest
{
   

    public class DeleteServiceRequestCommand : IRequest<int>
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

    }
}
