using FluentValidation;

namespace CustomerExperience.Application.Commands.Customers.CreateCustomer
{
  

    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(400);
        }
    }
}
