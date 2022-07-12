using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentfy.Domain.Entities;

namespace Rentfy.Data.Mapping
{
    public class LegalPersonMapping : IEntityTypeConfiguration<LegalPerson>
    {
        public void Configure(EntityTypeBuilder<LegalPerson> builder)
        {
            builder.ToTable("LegalPerson");

            builder.Property(builder => builder.FantasyName)
                .HasMaxLength(200);

            builder.OwnsOne(x => x.CNPJ)
                .Property(y => y.Number)
                .HasMaxLength(14)
                .HasColumnName(nameof(LegalPerson.CNPJ))
                .IsRequired();
        }
    }
}
