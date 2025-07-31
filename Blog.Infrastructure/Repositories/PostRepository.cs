using Blog.External.Infrastructure.Persistences.Contexts;
using Blog.External.Infrastructures.Persistences.Abstractions;
using Blog.Internal.Domains.Core.Entities.Posts;
using Microsoft.Extensions.Logging;

namespace Blog.Infrastructure.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(
            ILogger<Post> logger, MainContext queroGasContext) :
            base(logger, queroGasContext)
        {
        }
    }
}

