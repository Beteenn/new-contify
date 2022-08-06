using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentfy.Domain.Enumerations;

namespace Rentfy.Data.Mapping
{
    public class RentStatusEnumerationMapping : AEnumerationMapping<RentStatusEnumeration>
    {
        protected override void ConfigureProprerties(EntityTypeBuilder<RentStatusEnumeration> builder)
        {
            base.ConfigureProprerties(builder);
        }
    }
}
