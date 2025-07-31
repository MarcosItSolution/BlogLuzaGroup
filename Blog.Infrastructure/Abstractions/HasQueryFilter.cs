using Blog.Internal.Domains.Core.Entities.Posts;
using Blog.Internal.Domains.Core.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Blog.External.Infrastructures.Persistences.Abstractions
{
    public static class HasQueryFilter
    {
        public static void Apply(ModelBuilder modelBuilder)
        {
            #region -RuleOfDelete-

            modelBuilder.Entity<User>()
                .HasQueryFilter(a => a.Active && !a.Deleted);

            modelBuilder.Entity<Post>()
                .HasQueryFilter(a => a.Active);

            #endregion
        }
    }
}