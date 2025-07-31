using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Blog.Intenal.Domains.Core.Results;
using Blog.Internal.Applications.Core.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Blog.Internal.Applications.Commands.Users
{
    public class RegisterUserCommand : ICommand<CustomResult>
    {
        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;

        public sealed class RegisterUserCommandHandler :
            ICommandHandler<RegisterUserCommand, CustomResult>
        {
            private readonly IConfiguration _configuration;

            public RegisterUserCommandHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }


            public Task<CustomResult> HandlerAsync(
                RegisterUserCommand command,
                CancellationToken cancellationToken = default)
            {

                // Simula BadRequest
                if (string.IsNullOrWhiteSpace(command.UserName))
                {
                    Result failResult = Result.Failure(new Error("Login não informado."));
                    return Task.FromResult(new CustomResult(HttpStatusCode.BadRequest, failResult));
                }

                var jwtSettings = _configuration.GetSection("JwtSettings");
                var secret = jwtSettings["SecretKey"];

                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, command.UserName),
                    new Claim(ClaimTypes.Role, "User") 
                };

                var token = new JwtSecurityToken(
                    issuer: jwtSettings["Issuer"],
                    audience: jwtSettings["Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(2),
                    signingCredentials: creds
                );

                var tokenHandler = new JwtSecurityTokenHandler();
                string tokenGerado = tokenHandler.WriteToken(token);

                // Simula sucesso
                var successResult = Result.Success(new
                {
                    message = "Login realizado com sucesso (qualquer login/senha retornará sucesso)",
                    access_token = tokenGerado,
                    token_type = "Bearer"
                });

                return Task.FromResult(new CustomResult(HttpStatusCode.Created, successResult));
            }
        }
    }
}

