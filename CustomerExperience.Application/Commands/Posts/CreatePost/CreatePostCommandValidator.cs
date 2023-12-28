using CustomerExperience.Domain.PostAggregate;
using FluentValidation;


namespace CustomerExperience.Application.Commands.Posts.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Content)
                .NotNull()
                .NotEmpty()
                .MaximumLength(400);
        }
    }
}
