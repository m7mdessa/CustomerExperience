using CustomerExperience.Application.Commands.Posts.PostInteraction.React;
using CustomerExperience.Application.Commands.Posts.PostInteraction.UpdateReact;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace CustomerExperience.Presentation.API.Controllers.Posts
{
   

    public partial class PostsController
    {
        #region Commands


        [HttpPost("{postId}/postInteractions")]
        public async Task<ActionResult> React(int postId,
            [FromBody] ReactCommand command)
        {
            command.PostId = postId;

            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{postId}/postInteractions/{id}")]
        public async Task<ActionResult> UpdateReact(int postId, int id,
        [FromBody] UpdateReactCommand command)
        {
            command.PostId = postId;
            command.Id = id;

            return Ok(await _mediator.Send(command));
        }

       
        #endregion


    }
}
