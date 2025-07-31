using Blog.External.Infrastructures.Persistences.Abstractions;
using Blog.External.Infrastructures.Persistences.EntityConfigurations;
using Blog.Internal.Domains.Core.Entities.Posts;
using Blog.Internal.Domains.Core.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Blog.External.Infrastructure.Persistences.Contexts
{
    public class MainContext: DbContext
	{
        public MainContext(DbContextOptions<MainContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
		public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(
           DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableServiceProviderCaching();
            optionsBuilder.EnableSensitiveDataLogging();
            // .LogTo(Console.WriteLine);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ShadowProperties.Apply(modelBuilder);
            HasQueryFilter.Apply(modelBuilder);
            ConvectionDataType.Apply(modelBuilder);
            
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.UsePropertyAccessMode(PropertyAccessMode.Property);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

