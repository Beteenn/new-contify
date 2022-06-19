using Rentfy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentfy.Data.Mapping
{
    public class ObjetoTesteMapping : IEntityTypeConfiguration<ObjetoTeste>
    {
        public void Configure(EntityTypeBuilder<ObjetoTeste> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasMaxLength(80)
                .IsRequired();
        }
    }
}
