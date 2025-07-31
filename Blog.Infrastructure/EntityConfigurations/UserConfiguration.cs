using Blog.Internal.Domains.Core.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.External.Infrastructures.Persistences.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(p => p.Id).HasName("Id");

            builder.Property(p => p.Id).HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Username).HasColumnName("Username");
            builder.Property(p => p.Password).HasColumnName("Password");

            builder.HasMany(x => x.Posts)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .IsRequired();
        }
    }
}

