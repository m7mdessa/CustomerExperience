using CustomerExperience.Application.Commands.Posts.CreatePost;
using CustomerExperience.Domain.PostAggregate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExperience.Application.Commands.Posts.UpdatePost
{
    public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator()
        {
            RuleFor(x => x.Title)
                .MaximumLength(50);

            RuleFor(x => x.Content)
                .MaximumLength(400);
        }
    }
}
