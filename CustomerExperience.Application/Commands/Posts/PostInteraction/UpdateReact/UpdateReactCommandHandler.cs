using CustomerExperience.Domain.PostAggregate;
using CustomerExperience.Packages;
using MediatR;


namespace CustomerExperience.Application.Commands.Posts.PostInteraction.UpdateReact
{
    internal sealed class UpdateReactCommandHandler : IRequestHandler<UpdateReactCommand, Unit>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateReactCommandHandler(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateReactCommand command, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetAsync(command.PostId);

            post?.UpdateInteract(command.Id, command.CustomerId, command.InteractionType, command.PostId);

            await _postRepository.UpdateAsync(post);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }


    }
}
