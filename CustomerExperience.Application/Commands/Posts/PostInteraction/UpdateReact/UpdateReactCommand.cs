using CustomerExperience.Domain.PostAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExperience.Application.Commands.Posts.PostInteraction.UpdateReact
{
    public class UpdateReactCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int CustomerId { get; set; }
        public InteractionType InteractionType { get; set; }
    }
}
