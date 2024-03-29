﻿using CustomerExperience.Domain.PostAggregate;
using CustomerExperience.Packages;
using MediatR;

namespace CustomerExperience.Application.Commands.Posts.DeletePost
{
    internal sealed class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Unit>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeletePostCommandHandler(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeletePostCommand command, CancellationToken cancellationToken)
        {
            var postToDelete = await _postRepository.GetAsync(command.Id);
            postToDelete.RemovePost(command.Id);
            await _postRepository.DeleteAsync(postToDelete);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
