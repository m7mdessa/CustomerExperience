using CustomerExperience.Domain.PostAggregate;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExperience.Application.Queries.Posts.GetAllPosts
{
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
                .Map(dest => dest.PublishDate, src => src.PublishDate)
                .Map(dest => dest.Type, src => src.PostInteractions);
        }

        public async Task<List<GetAllPostsDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAllAsync();
            return posts.Select(post => post.Adapt<GetAllPostsDto>()).ToList();
        }
    }
}
