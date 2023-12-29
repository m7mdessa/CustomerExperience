using MediatR;

namespace CustomerExperience.Application.Commands.Customers.ServiceRequests.UpdateServiceRequest
{
 
    public class UpdateServiceRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestDescription { get; set; }
    }
}
