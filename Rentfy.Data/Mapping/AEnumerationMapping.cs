using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentfy.Domain.SeedWork;

namespace Rentfy.Data.Mapping
{
    public abstract class AEnumerationMapping<TEnumeration> : IEntityTypeConfiguration<TEnumeration>
            where TEnumeration : AEnumeration
    {
        public void Configure(EntityTypeBuilder<TEnumeration> builder)
        {
            builder.ToTable(typeof(TEnumeration).Name.Replace("Enumeration", string.Empty));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
               .ValueGeneratedNever()
               .IsRequired();

            ConfigureProprerties(builder);
        }

        protected virtual void ConfigureProprerties(EntityTypeBuilder<TEnumeration> builder)
        {
            builder.Property(t => t.Name)
                .HasColumnName("Name")
                .HasMaxLength(80)
                .IsRequired();
        }
    }
}
