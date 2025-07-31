using Blog.External.Infrastructure.Persistences.Contexts;
using Blog.External.Infrastructures.Persistences.Abstractions;
using Blog.Internal.Domains.Core.Entities.Users;
using Microsoft.Extensions.Logging;

namespace Blog.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(
            ILogger<User> logger, MainContext queroGasContext) :
            base(logger, queroGasContext)
        {
        }
    }
}

