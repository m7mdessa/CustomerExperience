using CustomerExperience.Application.Commands.Customers.CreateCustomer;
using CustomerExperience.Domain.CustomerAggregate;
using CustomerExperience.Packages;
using MediatR;


namespace CustomerExperience.Application.Commands.Customers.UpdateCustomer
{
   

    internal sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;


        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {

            var customer = await _customerRepository.GetByIdAsync(command.Id);

            var address = new Address(
                command.Street,
                command.City,
                command.State,
                command.Country,
                command.ZipCode);

            customer.UpdateCustomer(
                command.Id,
                command.FirstName,
                command.LastName,
                command.Email,
                command.PhoneNumber,
                address);
         

            await _customerRepository.UpdateAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            return customer.Id;



        }
    }

}
