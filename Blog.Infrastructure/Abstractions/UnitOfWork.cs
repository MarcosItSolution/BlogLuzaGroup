using Blog.External.Infrastructure.Persistences.Contexts;
using Blog.Intenal.Domains.Core.Abstractions;
using Blog.Intenal.Domains.Core.Results;
using Blog.Internal.Domains.Core.Entities.Posts;
using Blog.Internal.Domains.Core.Entities.Users;

namespace Blog.External.Infrastructures.Persistences.Abstractions
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MainContext _context;

        public UnitOfWork(
            MainContext context,
            IUserRepository userRepository,
            IPostRepository postRepository
            )
        {
            _context = context;
            UserRepository = userRepository;
            PostRepository = postRepository;
        }

        public IUserRepository UserRepository { get; }
        public IPostRepository PostRepository { get; }

        public async Task<Result> CommitAsync(
            CancellationToken cancellationToken)
        {
            //Todo: Analisar o processo de conclusão
            await Task.Delay(0);
            var result = await _context.SaveChangesAsync(cancellationToken);

            if (result <= 0)
            {
                var error = new Error(
                    "Operations.Commit",
                    $"Não foi possivel concluir o processo." +
                    $"\nDetalhes: {result}");

                return Result.Failure(error);
            }

            return Result.Success(result);
        }

        public void RollbackAsync()
        {
            _context.Dispose();
        }

        public void Dispose()
        {
            GC.Collect();
            _context.Dispose();
        }
    }
}

