
using Blog.Intenal.Domains.Core.Results;
using Blog.Internal.Domains.Core.Entities.Posts;
using Blog.Internal.Domains.Core.Entities.Users;

namespace Blog.Intenal.Domains.Core.Abstractions
{
    public interface IUnitOfWork
	{
        IUserRepository UserRepository { get; }
        IPostRepository PostRepository { get; }

        Task<Result> CommitAsync(CancellationToken cancellationToken);

		void RollbackAsync();
	}
}