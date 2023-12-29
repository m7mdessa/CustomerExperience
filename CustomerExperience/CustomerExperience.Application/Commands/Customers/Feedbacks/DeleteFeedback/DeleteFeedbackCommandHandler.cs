using CustomerExperience.Domain.CustomerAggregate;
using CustomerExperience.Packages;
using MediatR;

namespace CustomerExperience.Application.Commands.Customers.Feedbacks.DeleteFeedback
{
    
 

    internal sealed class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;


        public DeleteFeedbackCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteFeedbackCommand command, CancellationToken cancellationToken)
        {

            var customer = await _customerRepository.GetByIdAsync(command.CustomerId, fb => fb.Feedbacks);

            var feedBack = customer.Feedbacks.FirstOrDefault(fb => fb.Id == command.Id);

            customer.RemoveFeedback(feedBack);
                
            await _customerRepository.UpdateAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            return customer.Id;



        }
    }

}
