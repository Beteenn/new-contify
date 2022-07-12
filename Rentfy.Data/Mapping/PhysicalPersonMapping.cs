using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentfy.Domain.Entities;

namespace Rentfy.Data.Mapping
{
    public class PhysicalPersonMapping : IEntityTypeConfiguration<PhysicalPerson>
    {
        public void Configure(EntityTypeBuilder<PhysicalPerson> builder)
        {
            builder.ToTable("PhysicalPerson");

            builder.Property(x => x.LastName)
                .HasMaxLength(100);

            builder.Property(x => x.BirthDate)
                .HasColumnType("Date");

            builder.OwnsOne(x => x.CPF)
                .Property(y => y.Number)
                .HasMaxLength(11)
                .HasColumnName(nameof(PhysicalPerson.CPF))
                .IsRequired();
        }
    }
}
