using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentfy.Domain.Entities;

namespace Rentfy.Data.Mapping
{
    public class RentProductMapping : IEntityTypeConfiguration<RentProduct>
    {
        public void Configure(EntityTypeBuilder<RentProduct> builder)
        {
            builder.ToTable("RentProduct");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(200);

            builder.Property(x => x.HourValue);

            builder.Property(x => x.CategoryName);
        }
    }
}
