using CustomerExperience.Domain.CustomerAggregate;
using CustomerExperience.Packages;
using MediatR;

namespace CustomerExperience.Application.Commands.Customers.ServiceRequests.UpdateServiceRequest
{
 

    internal sealed class UpdateServiceRequestCommandHandler : IRequestHandler<UpdateServiceRequestCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;


        public UpdateServiceRequestCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateServiceRequestCommand command, CancellationToken cancellationToken)
        {

            var customer = await _customerRepository.GetByIdAsync(command.CustomerId, fb => fb.Feedbacks);


            customer.UpdateServiceRequest(
                command.Id,
                command.CustomerId,
                command.RequestDate,
                command.RequestDescription
               );


            await _customerRepository.UpdateAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;



        }
    }

}
