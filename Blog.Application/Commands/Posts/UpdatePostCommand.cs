using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Blog.Intenal.Domains.Core.Abstractions;
using Blog.Intenal.Domains.Core.Results;
using Blog.Internal.Applications.Core.Abstractions;
using Blog.Internal.Domains.Core.Entities.Posts;

namespace Blog.Internal.Applications.Core.Commands.Posts
{
    public class UpdatePostCommand : ICommand<CustomResult>
    {
        [JsonIgnore]
        public int id { get; set; }

        [Required]
        public string Title { get; set; } = default!;

        [Required]
        public string Content { get; set; } = default!;

        //Todo: Capturar o ID no token de autenticação
        [Required]
        public int CurrentUserId { get; set; }


        public sealed class UpdatePostCommandHandler :
            ICommandHandler<UpdatePostCommand, CustomResult>
        {
            private readonly IUnitOfWork _unitOfWork;

            public UpdatePostCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<CustomResult> HandlerAsync(
                UpdatePostCommand command,
                CancellationToken cancellationToken = default)
            {
                try
                {
                    var result = await _unitOfWork.PostRepository
                                .GetByIdAsync(command.id, cancellationToken);

                    if (result.Data is not Post post)
                    {
                        return result;
                    }

                    post.ChangeTile(command.Title, command.CurrentUserId);
                    post.ChangeContent(command.Content, command.CurrentUserId);

                    if (post.IsValid())
                    {
                        await _unitOfWork.PostRepository
                            .UpdateAsync(post, cancellationToken);

                        var response = await _unitOfWork.CommitAsync(cancellationToken);

                        if (response.IsFailure)
                        {
                            return CustomResult.ExpectationFailed(
                                new Error(response.Error));
                        }

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
