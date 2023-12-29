using CustomerExperience.Domain.CustomerAggregate;
using CustomerExperience.Packages;
using MediatR;


namespace CustomerExperience.Application.Commands.Customers.Feedbacks.AddFeedback
{
   
    internal sealed class AddFeedbackCommandHandler : IRequestHandler<AddFeedbackCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;


        public AddFeedbackCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddFeedbackCommand command, CancellationToken cancellationToken)
        {

            var customer = await _customerRepository.GetByIdAsync(command.CustomerId);

         
            customer.AddFeedback(
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
