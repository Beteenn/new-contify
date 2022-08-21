using System;
using System.Collections.Generic;

namespace Rentfy.Application.ViewModels
{
    public class RentViewModel
    {
        public long Id { get; private set; }
        public UserViewModel Client { get; private set; }
        public StoreViewModel Store { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime ReservationDate { get; private set; }
        public DateTime CancellationDate { get; private set; }
        public long TotalValue { get; private set; }
        public EnumViewModel Status { get; private set; }
        public IList<ProductViewModel> Products { get; private set; }
    }
}
