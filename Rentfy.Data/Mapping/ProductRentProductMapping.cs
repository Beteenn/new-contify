using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentfy.Domain.Entities;

namespace Rentfy.Data.Mapping
{
    public class ProductRentProductMapping : IEntityTypeConfiguration<ProductRentProduct>
    {
        public void Configure(EntityTypeBuilder<ProductRentProduct> builder)
        {
            builder.ToTable("ProductRentProduct");

            builder.HasKey(x => new { x.ProductRentId, x.RentId });

            builder.HasOne(x => x.ProductRent)
                .WithMany()
                .HasForeignKey(x => x.ProductRentId);

            builder.HasOne(x => x.Rent)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.RentId);
        }
    }
}
