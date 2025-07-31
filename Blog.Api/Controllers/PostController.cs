using Blog.Intenal.Domains.Core.Results;
using Blog.Internal.Applications.Core.Abstractions;
using Blog.Internal.Applications.Core.Commands.Posts;
using Blog.Internal.Applications.Core.Queries.Posts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.External.Presentations.Api.Controllers
{
    public class PostController : BaseController<PostController>
    {
        public PostController(
            ILogger<PostController> logger, Dispatcher dispatcher) :
            base(logger, dispatcher) { }

        // GET: api/values
        [HttpGet("getposts")]
        public async Task<IActionResult> GetPostsAsync(
            CancellationToken cancellationToken)
        {
            var query = new GetPostsByIdQuery();

            var result = await _dispatcher
            .QueryAsync< GetPostsByIdQuery, CustomResult>(
                query, cancellationToken);

            return ResponseApi(result);
        }

        // GET api/values/5
        [HttpGet("getpost/{id}")]
        public async Task<IActionResult> GetPostAsync(
            [FromQuery] GetPostsByIdQuery query,
            CancellationToken cancellationToken)
        {
            var result = await _dispatcher
                .QueryAsync<
                    GetPostsByIdQuery, CustomResult>(
                    query, cancellationToken);

            return ResponseApi(result);
        }

        // POST api/values
        [HttpPost("newpost")]
        public async Task<IActionResult> PostAsync(
            [FromBody] CreatePostCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _dispatcher
                .CommandAsync<CreatePostCommand, CustomResult>(
                    command, cancellationToken);

            return ResponseApi(result);
        }

        // PUT api/values/5
        [HttpPut("updatepost/{id}")]
        public async Task<IActionResult> PutAsync(
            int id,
            [FromBody] UpdatePostCommand command,
            CancellationToken cancellationToken)
        {
            command.id = id;

            var result = await _dispatcher
                .CommandAsync<UpdatePostCommand, CustomResult>(
                    command, cancellationToken);

            return ResponseApi(result);
        }

        // DELETE api/values/5
        [HttpDelete("removepost/{id}")]
        public async Task<IActionResult> Delete(
            int id, CancellationToken cancellationToken)
        {
            var command = new DeletePostCommand();
            command.Id = id;

            var result = await _dispatcher
                .CommandAsync<DeletePostCommand, CustomResult>(
                    command, cancellationToken);

            return ResponseApi(result);
        }
    }
}

