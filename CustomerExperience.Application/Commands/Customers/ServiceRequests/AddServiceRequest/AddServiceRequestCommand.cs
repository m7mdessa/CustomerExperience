
using MediatR;

namespace CustomerExperience.Application.Commands.Customers.ServiceRequests.AddServiceRequest
{
    public class AddServiceRequestCommand:IRequest<int>
    {
        public int CustomerId { get;  set; }
        public DateTime RequestDate { get;  set; }
        public string RequestDescription { get;  set; }
    }


}
