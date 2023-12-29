using CustomerExperience.Domain.CustomerAggregate;
using Mapster;
using MediatR;


namespace CustomerExperience.Application.Queries.Customers.ServiceRequests
{
    
    public static class GetServiceRequestList
    {

        public record GetServiceRequestListQuery(int customerId) : IRequest<List<GetServiceRequestListDto>>;


        internal sealed class GetServiceRequestListQueryHandler : IRequestHandler<GetServiceRequestListQuery, List<GetServiceRequestListDto>>
        {
            private readonly ICustomerRepository _customerRepository;

            public GetServiceRequestListQueryHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
                TypeAdapterConfig<ServiceRequest, GetServiceRequestListDto>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.CustomerId, src => src.CustomerId)
                .Map(dest => dest.RequestDate, src => src.RequestDate)
                .Map(dest => dest.RequestDescription, src => src.RequestDescription);

            }

            public async Task<List<GetServiceRequestListDto>> Handle(GetServiceRequestListQuery request, CancellationToken cancellationToken)
            {

                var customer = await _customerRepository.GetByIdAsync(request.customerId, sr => sr.ServiceRequests);

                var serviceRequests = customer.ServiceRequests;

                var data = serviceRequests?.Adapt<List<GetServiceRequestListDto>>();


                return data;


            }
        }
    }

    public class GetServiceRequestListDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestDescription { get; set; }


    }
}
