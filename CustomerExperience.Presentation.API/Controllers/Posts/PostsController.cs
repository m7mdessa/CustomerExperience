using MediatR;
using Microsoft.AspNetCore.Mvc;
using CustomerExperience.Application.Commands.Posts.UpdatePost;
using CustomerExperience.Application.Commands.Posts.CreatePost;


namespace PostExperience.Presentation.API.Controllers.Posts
{
   

    public partial class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;


        public PostsController(IMediator mediator)
        {
            _mediator = mediator;

        }

        #region Commands

        [HttpPost("CreatePost")]
        public async Task<ActionResult> CreatePost([FromBody] CreatePostCommand command)
        {

            return Ok(await _mediator.Send(command));

        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePost(int id,
            [FromBody] UpdatePostCommand command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }


        #endregion



    }
}
