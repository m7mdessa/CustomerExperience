using MediatR;
using Microsoft.AspNetCore.Mvc;
using CustomerExperience.Application.Commands.Posts.UpdatePost;
using CustomerExperience.Application.Commands.Posts.CreatePost;
using CustomerExperience.Application.Commands.Posts.PostInteraction.React;
using CustomerExperience.Application.Commands.Posts.PostInteraction.UpdateReact;
using CustomerExperience.Domain.PostAggregate;
using static CustomerExperience.Application.Queries.Posts.GelPostsList;
using CustomerExperience.Application.Queries.Posts;
using static CustomerExperience.Application.Queries.Posts.GetPostDetails;


namespace PostExperience.Presentation.API.Controllers.Posts
{

    [Route("api/[controller]")]
    [ApiController]
    public partial class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Commands

        [HttpPost("createPost")]
        public async Task<ActionResult> CreatePost([FromBody] CreatePostCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePost(int id, [FromBody] UpdatePostCommand command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }


        [HttpPut("{postId}/postInteractions/{id}")]
        public async Task<ActionResult> UpdateReact(int postId, int id, [FromBody] UpdateReactCommand command)
        {
            command.PostId = postId;
            command.Id = id;
            command.InteractionType = command.IsLike ? InteractionType.Like : InteractionType.Dislike;
            switch (command.InteractionType)
            {
                case InteractionType.Like:
                    command.IsLike = true;
                    command.InteractionType = InteractionType.Like;
                    break;

                case InteractionType.Dislike:
                    command.IsLike = false;
                    command.InteractionType = InteractionType.Dislike;
                    break;

                default:
                    // Handle other cases if necessary
                    break;
            }
            return Ok(await _mediator.Send(command));
        }

        

        [HttpPost("{postId}/postInteractions")]
        public async Task<ActionResult> React(int postId, [FromBody] ReactCommand command)
        {
            command.PostId = postId;
            command.InteractionType = command.IsLike ? InteractionType.Like : InteractionType.Dislike;
            switch (command.InteractionType)
            {
                case InteractionType.Like:
                    command.IsLike = true;
                    command.InteractionType = InteractionType.Like;
                    break;

                case InteractionType.Dislike:
                    command.IsLike = false;
                    command.InteractionType = InteractionType.Dislike;
                    break;

                default:
                    // Handle other cases if necessary
                    break;
            }

            return Ok(await _mediator.Send(command));
        }

        #endregion

        #region Queries
        [HttpGet("getAllPosts")]
        public async Task<ActionResult<List<GetAllPostsDto>>> GetAllPosts()
        {
            var posts = await _mediator.Send(new GetAllPostsQuery());
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Post>>> GetPostById(int id)
        {
            var post = await _mediator.Send(new GetPostDetailsQuery { Id = id });
            return Ok(post);
        }

        #endregion
    }
}
