using Rentfy.Domain.SeedWork;

namespace Rentfy.Domain.Enumerations
{
    public class RentStatusEnumeration : AEnumeration<RentStatusEnumeration>
    {
        public RentStatusEnumeration(int id, string name) : base(id, name)
        {
        }

        public static RentStatusEnumeration Active = new RentStatusEnumeration(1, "Active");
        public static RentStatusEnumeration Pending = new RentStatusEnumeration(2, "Pending");
        public static RentStatusEnumeration Canceled = new RentStatusEnumeration(3, "Canceled");
        public static RentStatusEnumeration Closed = new RentStatusEnumeration(4, "Closed");
    }
}
