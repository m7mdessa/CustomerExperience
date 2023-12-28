using CustomerExperience.Domain.PostAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExperience.Application.Commands.Posts.PostInteraction.React
{
    public class ReactCommand : IRequest<int>
    {
        public int PostId { get; set; }
        public int CustomerId { get; set; }
        public InteractionType InteractionType { get; set; }
    }
}
