using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentfy.Domain.Entities;

namespace Rentfy.Data.Mapping
{
    public class StoreMapping : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Store");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.LegalPerson)
                .WithMany()
                .HasForeignKey(x => x.LegalPersonId);

            builder.HasMany(x => x.Products)
                .WithOne(y => y.Store)
                .HasForeignKey(x => x.StoreId);

        }
    }
}
