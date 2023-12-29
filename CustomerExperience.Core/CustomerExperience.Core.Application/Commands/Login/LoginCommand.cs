using MediatR;


namespace CustomerExperience.Core.Application.Commands.Login
{
    public class LoginCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
 
    }
}
