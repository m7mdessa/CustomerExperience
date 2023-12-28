using CustomerExperience.Domain.PostAggregate;
using CustomerExperience.Packages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExperience.Application.Commands.Posts.UpdatePost
{
    internal sealed class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Unit>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePostCommandHandler(IPostRepository postRepository, IUnitOfWork unitOfWork) 
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdatePostCommand command, CancellationToken cancellationToken)
        {
            var existingPost = await _postRepository.GetAsync(command.Id);
            existingPost.UpdatePost(command.Id, command.Title, command.Content);
            await _postRepository.UpdateAsync(existingPost);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }

    }
}
