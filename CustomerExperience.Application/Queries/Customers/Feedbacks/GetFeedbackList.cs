using CustomerExperience.Domain.CustomerAggregate;
using Mapster;
using MediatR;

namespace CustomerExperience.Application.Queries.Customers.Feedbacks
{
 


    public static class GetFeedbackList
    {

        public record GetFeedbackListQuery(int customerId) : IRequest<List<GetFeedbackListDto>>;


        internal sealed class GetFeedbackListQueryHandler : IRequestHandler<GetFeedbackListQuery, List<GetFeedbackListDto>>
        {
            private readonly ICustomerRepository _customerRepository;

            public GetFeedbackListQueryHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
                TypeAdapterConfig<Feedback, GetFeedbackListDto>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.CustomerId, src => src.CustomerId)
                .Map(dest => dest.FeedbackDate, src => src.FeedbackDate)
                .Map(dest => dest.FeedbackText, src => src.FeedbackText);
             

            }

            public async Task<List<GetFeedbackListDto>> Handle(GetFeedbackListQuery request, CancellationToken cancellationToken)
            {

                var customer = await _customerRepository.GetByIdAsync(request.customerId,fb=> fb.Feedbacks);

                var feedBacks = customer.Feedbacks;

                var data = feedBacks?.Adapt<List<GetFeedbackListDto>>();


                return data;


            }
        }
    }

    public class GetFeedbackListDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public DateTime FeedbackDate { get; set; }
        public string FeedbackText { get; set; }

    }
}
