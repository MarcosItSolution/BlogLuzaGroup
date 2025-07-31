using System.ComponentModel.DataAnnotations;
using Blog.Intenal.Domains.Core.Abstractions;
using Blog.Intenal.Domains.Core.Results;
using Blog.Internal.Applications.Core.Abstractions;
using Blog.Internal.Applications.Core.Services;
using Blog.Internal.Domains.Core.Entities.Posts;

namespace Blog.Internal.Applications.Core.Commands.Posts
{
    public class CreatePostCommand : ICommand<CustomResult>
    {
        [Required]
        public string Title { get; set; } = default!;

        [Required]
        public string Content { get; set; } = default!;

        //Todo: Capturar o ID no token de autenticação
        [Required]
        public int CurrentUserId { get; set; }

        public sealed class CreatePostCommandHandler :
            ICommandHandler<CreatePostCommand, CustomResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly WebSocketHandler _webSocketHandler;

            public CreatePostCommandHandler(
                IUnitOfWork unitOfWork, WebSocketHandler webSocketHandler)
            {
                _unitOfWork = unitOfWork;
                _webSocketHandler = webSocketHandler;
            }

            public async Task<CustomResult> HandlerAsync(
                CreatePostCommand command,
                CancellationToken cancellationToken = default)
            {
                try
                {
                    var post = new Post(command.Title, command.Content, command.CurrentUserId);

                    if (post.IsValid())
                    {
                        await _unitOfWork.PostRepository
                            .CreateAsync(post, cancellationToken);


                        var response = await _unitOfWork.CommitAsync(
                            cancellationToken);

                        if (response.IsFailure)
                        {
                            return CustomResult.ExpectationFailed(
                                new Error(response.Error));
                        }

                        // Dispara notificação para WebSockets
                        var message = $"Nova postagem publicada: {post.Title}";

                        await _webSocketHandler.NotifyAllAsync(
                            message, cancellationToken);

                        return CustomResult.Ok(response);
                    }
                    else
                    {
                        return CustomResult.ExpectationFailed(
                            PostErrors.InvalidFields);
                    }
                }
                catch (Exception ex)
                {
                    var erro = new Error("Exception", ex.Message);

                    return CustomResult.Exception(erro);
                }
            }
        }
    }
}

