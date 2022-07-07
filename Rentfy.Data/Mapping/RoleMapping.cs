using Rentfy.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rentfy.Data.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).HasMaxLength(50);
            builder.Property(u => u.NormalizedName).HasMaxLength(50);
        }
    }
}
