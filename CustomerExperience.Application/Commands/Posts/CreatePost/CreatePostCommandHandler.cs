using CustomerExperience.Domain.CategoryAggregate;
using CustomerExperience.Domain.PostAggregate;
using CustomerExperience.Packages;
using MediatR;


namespace CustomerExperience.Application.Commands.Posts.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePostCommandHandler(IPostRepository postRepository,IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreatePostCommand definitionCommand,CancellationToken cancellationToken)
        {
            var post = new Post(
                definitionCommand.Title,
                definitionCommand.Content

            );
            await _postRepository.AddAsync(post);
            await _unitOfWork.SaveChangesAsync();
            return post.Id;
        }
    }
}
