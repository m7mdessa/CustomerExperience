using CustomerExperience.Domain.PostAggregate;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExperience.Application.Queries.Posts
{
    public static class GelPostsList
    {
        #region Dtos
        public class GetAllPostsDto
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
        public record GetAllPostsQuery : IRequest<List<GetAllPostsDto>>;
        #endregion

        #region Handler
        internal sealed class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, List<GetAllPostsDto>>
        {
            private readonly IPostRepository _postRepository;

            public GetAllPostsQueryHandler(IPostRepository postRepository)
            {
                _postRepository = postRepository;

                TypeAdapterConfig<Post, GetAllPostsDto>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Content, src => src.Content)
                .Map(dest => dest.PublishDate, src => src.PublishDate);
            }

            public async Task<List<GetAllPostsDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
            {
                var postsWithInteractions = await _postRepository.GetAllAsync(pi=>pi.PostInteractions);
                TypeAdapterConfig<Post, GetAllPostsDto>
                .ForType()
                .Map(dest => dest.Interactions, src => src.PostInteractions);

                var dtos = postsWithInteractions.Adapt<List<GetAllPostsDto>>();

                return dtos;
            }
        }

        #endregion
    }
}
