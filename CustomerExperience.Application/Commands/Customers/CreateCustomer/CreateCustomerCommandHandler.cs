using CustomerExperience.Domain.CustomerAggregate;
using CustomerExperience.Domain.PostAggregate;
using CustomerExperience.Packages;
using MediatR;

namespace CustomerExperience.Application.Commands.Customers.CreateCustomer
{
    
    internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;


        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
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
            await _unitOfWork.SaveChangesAsync();

            return customer.Id;



        }
    }


}
