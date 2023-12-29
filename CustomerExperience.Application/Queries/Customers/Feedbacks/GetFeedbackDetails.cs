using CustomerExperience.Domain.CustomerAggregate;
using Mapster;
using MediatR;

namespace CustomerExperience.Application.Queries.Customers.Feedbacks
{
    public static class GetFeedbackDetails
    {

        public record GetFeedbackDetailsQuery(int id,int customerId) : IRequest<GetFeedbackDetailsDto>;


        internal sealed class GetFeedbackDetailsQueryHandler : IRequestHandler<GetFeedbackDetailsQuery, GetFeedbackDetailsDto>
        {
            private readonly ICustomerRepository _customerRepository;

            public GetFeedbackDetailsQueryHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
                TypeAdapterConfig<Feedback, GetFeedbackDetailsDto>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.CustomerId, src => src.CustomerId)
                .Map(dest => dest.FeedbackDate, src => src.FeedbackDate)
                .Map(dest => dest.FeedbackText, src => src.FeedbackText);


            }

            public async Task<GetFeedbackDetailsDto> Handle(GetFeedbackDetailsQuery request, CancellationToken cancellationToken)
            {

                var customer = await _customerRepository.GetByIdAsync(request.customerId, fb => fb.Feedbacks);

                var feedback = customer.Feedbacks.FirstOrDefault(s => s.Id == request.id);


                var data = feedback?.Adapt<GetFeedbackDetailsDto>();


                return data;


            }
        }
    }

    public class GetFeedbackDetailsDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public DateTime FeedbackDate { get; set; }
        public string FeedbackText { get; set; }

    }
}
