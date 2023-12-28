using CustomerExperience.Domain.PostAggregate;
using CustomerExperience.Packages;
using MediatR;


namespace CustomerExperience.Application.Commands.Posts.CreatePost
{
    internal sealed class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePostCommandHandler(IPostRepository postRepository,IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreatePostCommand command,CancellationToken cancellationToken)
        {
            var post = new Post(
                command.Title,
                command.Content
            );

            await _postRepository.AddAsync(post);
            await _unitOfWork.SaveChangesAsync();
            return post.Id;
        }
    }
}
