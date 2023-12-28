using CustomerExperience.Domain.CustomerAggregate;
using MediatR;

namespace CustomerExperience.Application.Commands.Customers.CreateCustomer
{
    
    internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
   

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
          
        }

        public async Task<int> Handle(CreateCustomerCommand command,CancellationToken cancellationToken)
        {
            var address = new Address(
                command.Street,
                command.City,
                command.State,
                command.Country,
                command.ZipCode);

            var customer = new Customer(
                command.FirstName,
                command.LastName,
                command.Email,
                command.PhoneNumber,
                address
            );

            await _customerRepository.AddAsync(customer);
            return customer.id;
        }
    }


}
