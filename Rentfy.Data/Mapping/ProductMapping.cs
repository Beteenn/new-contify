using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentfy.Domain.Entities;

namespace Rentfy.Data.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(200);

            builder.Property(x => x.Amount);

            builder.Property(x => x.RentedAmount);

            builder.Property(x => x.HourValue);


            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
