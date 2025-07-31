using System;
using System.ComponentModel.DataAnnotations;
using Blog.Intenal.Domains.Core.Results;
using Blog.Internal.Applications.Core.Abstractions;

namespace Blog.Internal.Applications.Commands.Users
{
	public class LoginUserCommand : ICommand<CustomResult>
    {
        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;

        public sealed class LoginUserCommandHandler :
            ICommandHandler<LoginUserCommand, CustomResult>
        {
            public Task<CustomResult> HandlerAsync(
                LoginUserCommand command,
                CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }
        }
    }
}

