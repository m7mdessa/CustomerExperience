using CustomerExperience.Domain.PostAggregate;
using Mapster;
using MediatR;

namespace CustomerExperience.Application.Queries.Posts
{
    public static class GetPostDetails
    {

        #region Dtos
        public class PostWithInteractionsDto
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public DateTime PublishDate { get; set; }
            public List<InteractionDto> Interactions { get; set; }
        }

        public class InteractionDto
        {
            public InteractionType Type { get; set; }
            public DateTime Timestamp { get; set; }
            public int CustomerId { get; set; }
        }
        #endregion

        #region Query
        public class GetPostDetailsQuery : IRequest<PostWithInteractionsDto>
        {
            public int Id { get; set; }
        }
        #endregion

        #region Handler
        internal sealed class GetPostDetailsQueryHandler : IRequestHandler<GetPostDetailsQuery,PostWithInteractionsDto>
        {
            private readonly IPostRepository _postRepository;

            public GetPostDetailsQueryHandler(IPostRepository postRepository)
            {
                _postRepository = postRepository;

                TypeAdapterConfig<Post, PostWithInteractionsDto>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Content, src => src.Content)
                .Map(dest => dest.PublishDate, src => src.PublishDate);
            }

            public async Task<PostWithInteractionsDto>Handle(GetPostDetailsQuery command, CancellationToken cancellationToken)
            {
                var postsWithInteractions = await _postRepository.GetByIdAsync(command.Id,pi => pi.PostInteractions);
                TypeAdapterConfig<Post, PostWithInteractionsDto>
                .ForType()
                .Map(dest => dest.Interactions, src => src.PostInteractions);

                var dtos = postsWithInteractions.Adapt<PostWithInteractionsDto>();

                return dtos;
            }
        }
        #endregion
    }
}
