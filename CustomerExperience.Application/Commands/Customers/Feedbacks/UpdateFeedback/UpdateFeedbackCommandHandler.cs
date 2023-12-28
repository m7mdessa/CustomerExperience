using CustomerExperience.Domain.CustomerAggregate;
using CustomerExperience.Packages;
using MediatR;


namespace CustomerExperience.Application.Commands.Customers.Feedbacks.UpdateFeedback
{

    internal sealed class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;


        public UpdateFeedbackCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdateFeedbackCommand command, CancellationToken cancellationToken)
        {

            var customer = await _customerRepository.GetByIdAsync(command.CustomerId, fb => fb.Feedbacks);


            customer.UpdateFeedback(
                command.Id,
                command.CustomerId,
                command.FeedbackDate,
                command.FeedbackText
               );


            await _customerRepository.UpdateAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            return customer.Id;



        }
    }

}
