using CustomerExperience.Core.Domain.RoleAggregate;
using MassTransit;
using MediatR;


namespace CustomerExperience.Core.Application.Commands.CreateUser
{
    internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IRoleRepository _roleRepository;
        //private readonly IBus _bus;

        public CreateUserCommandHandler(IRoleRepository roleRepository/*, IBus bus*/)
        {

            _roleRepository = roleRepository;
            //_bus = bus;

        }
      
        public async Task<Unit> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByIdAsync(command.RoleId);
            role.AddUser(command.UserName , command.Password, command.RoleId, command.CustomerId);
            await _roleRepository.UpdateAsync(role);

            //var userAdded = new UserAdded
            //{
                
            //    UserName = command.UserName,
            //    CustomerId = command.CustomerId,

            //};

            //await _bus.Publish(userAdded);
            return Unit.Value;
        }

    }


    //public class UserAdded
    //{
     
    //    public string? UserName { get; set; }
    //    public int CustomerId { get; set; }


    //}



}
