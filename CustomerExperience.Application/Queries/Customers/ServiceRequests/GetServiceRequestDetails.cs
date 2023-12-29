using CustomerExperience.Domain.CustomerAggregate;
using Mapster;
using MediatR;


namespace CustomerExperience.Application.Queries.Customers.ServiceRequests
{
   

    public static class GetServiceRequestDetails
    {

        public record GetServiceRequestDetailsQuery(int id, int customerId) : IRequest<GetServiceRequestDetailsDto>;


        internal sealed class GetServiceRequestDetailsQueryHandler : IRequestHandler<GetServiceRequestDetailsQuery, GetServiceRequestDetailsDto>
        {
            private readonly ICustomerRepository _customerRepository;

            public GetServiceRequestDetailsQueryHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
                TypeAdapterConfig<ServiceRequest, GetServiceRequestDetailsDto>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.CustomerId, src => src.CustomerId)
                .Map(dest => dest.RequestDate, src => src.RequestDate)
                .Map(dest => dest.RequestDescription, src => src.RequestDescription);


            }

            public async Task<GetServiceRequestDetailsDto> Handle(GetServiceRequestDetailsQuery request, CancellationToken cancellationToken)
            {

                var customer = await _customerRepository.GetByIdAsync(request.customerId, sr => sr.ServiceRequests);

                var serviceRequest = customer.ServiceRequests.FirstOrDefault(s => s.Id == request.id);


                var data = serviceRequest?.Adapt<GetServiceRequestDetailsDto>();


                return data;


            }
        }
    }

    public class GetServiceRequestDetailsDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestDescription { get; set; }

    }
}
