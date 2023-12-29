using CustomerExperience.Core.Domain.RoleAggregate;
using MediatR;


namespace CustomerExperience.Core.Application.Commands.Login
{



    internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IRoleRepository _roleRepository;

        public LoginCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<string> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var role =  _roleRepository.Login(command.UserName, command.Password);
            return role;
        }
    }

}
