using CustomerExperience.Core.Domain.RoleAggregate;
using MediatR;


namespace CustomerExperience.Core.Application.Commands.CreateUser
{
    internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IRoleRepository _roleRepository;


        public CreateUserCommandHandler(IRoleRepository roleRepository)
        {

            _roleRepository = roleRepository;
        }

        public async Task<Unit> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByIdAsync(command.RoleId);
            role.AddUser(command.UserName , command.Password, command.RoleId, command.CustomerId);
            await _roleRepository.UpdateAsync(role);
            return Unit.Value;
        }

    }
}
