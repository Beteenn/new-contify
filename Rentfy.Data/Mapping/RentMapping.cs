using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentfy.Domain.Entities;

namespace Rentfy.Data.Mapping
{
    public class RentMapping : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.ToTable("Rent");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Client)
                .WithMany(x => x.Rents)
                .HasForeignKey(x => x.ClientId);

            builder.HasOne(x => x.Store)
                .WithMany(x => x.Rents)
                .HasForeignKey(x => x.StoreId);

            builder.HasOne(x => x.Status)
                .WithMany()
                .HasForeignKey(x => x.StatusId);

            builder.Property(x => x.StartDate);

            builder.Property(x => x.EndDate);

            builder.Property(x => x.ReservationDate);

            builder.Property(x => x.CancellationDate);

            builder.Property(x => x.TotalValue);

        }
    }
}
