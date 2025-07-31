using Blog.Intenal.Domains.Core.Results;
using Blog.Internal.Applications.Commands.Users;
using Blog.Internal.Applications.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.External.Presentations.Api.Controllers
{
    public class UserController : BaseController<UserController>
    {
        public UserController(
            ILogger<UserController> logger, Dispatcher dispatcher) :
            base(logger, dispatcher) { }

        
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(
            [FromBody] RegisterUserCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _dispatcher
                .CommandAsync<RegisterUserCommand, CustomResult>(
                    command, cancellationToken);

            return ResponseApi(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(
            [FromBody] RegisterUserCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _dispatcher
                .CommandAsync<RegisterUserCommand, CustomResult>(
                    command, cancellationToken);

            return ResponseApi(result);
        }
    }
}

