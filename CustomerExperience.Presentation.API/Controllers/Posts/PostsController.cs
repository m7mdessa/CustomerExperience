﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using CustomerExperience.Application.Commands.Posts.UpdatePost;
using CustomerExperience.Application.Commands.Posts.CreatePost;
using CustomerExperience.Application.Commands.Posts.PostInteraction.React;
using CustomerExperience.Application.Commands.Posts.PostInteraction.UpdateReact;


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

        [HttpPost("CreatePost")]
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


        [HttpPost("{postId}/postInteractions")]
        public async Task<ActionResult> React(int postId, [FromBody] ReactCommand command)
        {
            command.PostId = postId;

            return Ok(await _mediator.Send(command));

        }

        [HttpPut("{postId}/postInteractions/{id}")]
        public async Task<ActionResult> UpdateReact(int postId, int id, [FromBody] UpdateReactCommand command)
        {
            command.PostId = postId;
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }

        #endregion
    }
}