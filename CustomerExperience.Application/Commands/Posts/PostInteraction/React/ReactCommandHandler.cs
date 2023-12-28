using CustomerExperience.Domain.PostAggregate;
using CustomerExperience.Packages;
using MediatR;


namespace CustomerExperience.Application.Commands.Posts.PostInteraction.React
{
    internal sealed class ReactCommandHandler : IRequestHandler<ReactCommand, int>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReactCommandHandler(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(ReactCommand command, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetAsync(command.PostId);
            post.Interact(command.CustomerId, command.InteractionType, command.PostId);

            await _postRepository.UpdateAsync(post);
            await _unitOfWork.SaveChangesAsync();

            return post.Id;
        }
    }
}
