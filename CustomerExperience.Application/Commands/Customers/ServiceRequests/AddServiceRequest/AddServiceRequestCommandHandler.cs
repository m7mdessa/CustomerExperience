using CustomerExperience.Application.Commands.Customers.Feedbacks.AddFeedback;
using CustomerExperience.Domain.CustomerAggregate;
using CustomerExperience.Packages;
using MediatR;

namespace CustomerExperience.Application.Commands.Customers.ServiceRequests.AddServiceRequest
{
 
    internal sealed class AddServiceRequestCommandHandler : IRequestHandler<AddServiceRequestCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;


        public AddServiceRequestCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddServiceRequestCommand command, CancellationToken cancellationToken)
        {

            var customer = await _customerRepository.GetByIdAsync(command.CustomerId);


            customer.AddServiceRequest(
                command.CustomerId,
                command.RequestDate,
                command.RequestDescription
               );


            await _customerRepository.UpdateAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            return customer.Id;



        }
    }

}
