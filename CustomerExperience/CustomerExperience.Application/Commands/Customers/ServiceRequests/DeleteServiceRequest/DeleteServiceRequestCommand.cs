using MediatR;

namespace CustomerExperience.Application.Commands.Customers.ServiceRequests.DeleteServiceRequest
{
   

    public class DeleteServiceRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

    }
}
