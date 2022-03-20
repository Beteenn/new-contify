using Contify.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contify.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.UserName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.NormalizedUserName).HasMaxLength(50);
            builder.Property(u => u.Email).HasMaxLength(80);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(500);
            builder.Property(u => u.PasswordHash).HasMaxLength(85);
            builder.Property(u => u.SecurityStamp).HasMaxLength(50);
            builder.Property(u => u.ConcurrencyStamp).HasMaxLength(50).IsConcurrencyToken();
        }
    }
}
