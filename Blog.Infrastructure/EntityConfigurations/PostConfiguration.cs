using Blog.Internal.Domains.Core.Entities.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.External.Infrastructures.Persistences.EntityConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("post");
            builder.HasKey(p => p.Id).HasName("id");

            builder.Property(p => p.Id).HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Title).HasColumnName("title");
            builder.Property(p => p.Content).HasColumnName("content");
            builder.Property(p => p.UserId).HasColumnName("userId");

            builder.HasOne(x => x.User)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.Id)
                .IsRequired();
        }
    }
}