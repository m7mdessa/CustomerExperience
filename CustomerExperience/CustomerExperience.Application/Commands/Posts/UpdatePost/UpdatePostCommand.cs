using MediatR;

namespace CustomerExperience.Application.Commands.Posts.UpdatePost
{
    public class UpdatePostCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string ?Content { get; set; }
    }
}
