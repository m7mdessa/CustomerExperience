using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExperience.Core.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Unit>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CustomerId { get; set; }
        public int RoleId { get; set; }
    }
}
