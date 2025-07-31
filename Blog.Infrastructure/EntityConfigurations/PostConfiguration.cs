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
            builder.HasKey(p => p.Id).HasName("Id");

            builder.Property(p => p.Id).HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Title).HasColumnName("Title");
            builder.Property(p => p.Content).HasColumnName("Content");
            builder.Property(p => p.UserId).HasColumnName("UserId");

            builder.HasOne(x => x.User)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.Id)
                .IsRequired();
        }
    }
}