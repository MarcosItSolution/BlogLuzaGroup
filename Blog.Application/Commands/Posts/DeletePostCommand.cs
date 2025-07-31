using System.ComponentModel.DataAnnotations;
using Blog.Intenal.Domains.Core.Abstractions;
using Blog.Intenal.Domains.Core.Results;
using Blog.Internal.Applications.Core.Abstractions;
using Blog.Internal.Domains.Core.Entities.Posts;

namespace Blog.Internal.Applications.Core.Commands.Posts
{
    public class DeletePostCommand : ICommand<CustomResult>
    {
        [Required]
        public int Id { get; set; }

        //Todo: Capturar o ID no token de autenticação
        [Required]
        public int CurrentUserId { get; set; }

        public sealed class DeletePostCommandHandler :
            ICommandHandler<DeletePostCommand, CustomResult>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeletePostCommandHandler(
                IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<CustomResult> HandlerAsync(
                DeletePostCommand command,
                CancellationToken cancellationToken = default)
            {
                try
                {
                    var result = await _unitOfWork.PostRepository
                                .GetByIdAsync(command.Id, cancellationToken);

                    if (result.Data is not Post post)
                    {
                        return result;
                    }

                    post.Delete(command.CurrentUserId);

                    await _unitOfWork.PostRepository
                        .DeleteAsync(post, cancellationToken);

                    var response = await _unitOfWork.CommitAsync(cancellationToken);

                    if (response.IsFailure)
                    {
                        return CustomResult.ExpectationFailed(
                            new Error(response.Error));
                    }

                    return CustomResult.Ok(response);

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
