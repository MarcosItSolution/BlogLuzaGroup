using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Blog.Intenal.Domains.Core.Results;
using Blog.Internal.Applications.Core.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Internal.Applications.Commands.Users
{
	public class LoginUserCommand : ICommand<CustomResult>
    {
        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;

        [Required]
        public string Email { get; set; } = default!;

        [Required]
        public string Phone { get; set; } = default!;


        public sealed class LoginUserCommandHandler :
            ICommandHandler<LoginUserCommand, CustomResult>
        {
            public Task<CustomResult> HandlerAsync(
                LoginUserCommand command,
                CancellationToken cancellationToken = default)
            {

                // Simula BadRequest com mensagem de erro específica e tratada
                if (command.UserName == "invalido")
                {
                    Result failResult = Result.Failure(new Error("Já existe um usuário cadastrado com este Nome."));
                    return Task.FromResult(new CustomResult(HttpStatusCode.BadRequest, failResult));
                }

                // Simula sucesso
                var successResult = Result.Success(new
                {
                    message = "Usuário criado com sucessso",
                });

                return Task.FromResult(new CustomResult(HttpStatusCode.Created, successResult));

            }
        }
    }
}

