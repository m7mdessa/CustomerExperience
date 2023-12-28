using CustomerExperience.Domain.CustomerAggregate;
using CustomerExperience.Packages;
using MediatR;


namespace CustomerExperience.Application.Commands.Customers.ServiceRequests.DeleteServiceRequest
{
    

    internal sealed class DeleteServiceRequestCommandHandler : IRequestHandler<DeleteServiceRequestCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;


        public DeleteServiceRequestCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteServiceRequestCommand command, CancellationToken cancellationToken)
        {

            var customer = await _customerRepository.GetByIdAsync(command.CustomerId, fb => fb.Feedbacks);

            var serviceRequest = customer.ServiceRequests.FirstOrDefault(fb => fb.Id == command.Id);

            customer.RemoveServiceRequest(serviceRequest);

            await _customerRepository.UpdateAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            return customer.Id;



        }
    }

}
