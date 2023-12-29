
using CustomerExperience.Domain.CustomerAggregate;
using Mapster;
using MediatR;

namespace Application.Queries.Users
{
    public static  class GetCustomerDetails
    {

        public record GetCustomerDetailsQuery(int id) : IRequest<GetCustomerDetailsDto>;


        internal sealed class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, GetCustomerDetailsDto>
        {
            private readonly ICustomerRepository _customerRepository;

            public GetCustomerDetailsQueryHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
                TypeAdapterConfig<Customer, GetCustomerListDto>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.FirstName, src => src.FirstName)
                .Map(dest => dest.LastName, src => src.LastName)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.City, src => src.Address.City)
                .Map(dest => dest.Country, src => src.Address.Country)
                .Map(dest => dest.Street, src => src.Address.Street)
                .Map(dest => dest.State, src => src.Address.State)
                .Map(dest => dest.ZipCode, src => src.Address.ZipCode)
                .Map(dest => dest.PhoneNumber, src => src.PhoneNumber);

            }

            public async Task<GetCustomerDetailsDto> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
            {

                var customer = await _customerRepository.GetByIdAsync(request.id);


                var data = customer?.Adapt<GetCustomerDetailsDto>();

             
                return data;
            }
        }
    }
   
    public class GetCustomerDetailsDto
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }

        public string? Street { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public string? ZipCode { get; set; }
    }
}
