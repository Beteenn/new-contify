using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentfy.Domain.Entities;
using Rentfy.Domain.ValueObjects;

namespace Rentfy.Data.Mapping
{
    public class APersonMapping : IEntityTypeConfiguration<APerson>
    {
        public void Configure(EntityTypeBuilder<APerson> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(200);

            builder.OwnsOne(x => x.Email)
                .Property(y => y.Address)
                .HasMaxLength(200)
                .HasColumnName("Email");
        }
    }
}
