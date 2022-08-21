using Rentfy.Domain.Entities.Identity;
using Rentfy.Domain.Enumerations;
using System;
using System.Collections.Generic;

namespace Rentfy.Domain.Entities
{
    public class Rent
    {
        public long Id { get; private set; }
        public User Client { get; private set; }
        public long ClientId { get; private set; }
        public long StoreId { get; private set; }
        public Store Store { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime ReservationDate { get; private set; }
        public DateTime? CancellationDate { get; private set; }
        public long TotalValue { get; private set; }
        public int StatusId { get; private set; }
        public RentStatusEnumeration Status { get; private set; }
        public ICollection<ProductRentProduct> Products { get; private set; }

        public Rent() { }

        public Rent(long id, long clientId, long storeId, DateTime startDate, DateTime endDate)
        {
            Id = id;
            ClientId = clientId;
            StoreId = storeId;
            StartDate = startDate;
            EndDate = endDate;
            ReservationDate = DateTime.Now;
            StatusId = RentStatusEnumeration.Pending.Id;
        }

        public Rent(long clientId, long storeId, DateTime startDate, DateTime endDate)
        {
            ClientId = clientId;
            StoreId = storeId;
            StartDate = startDate;
            EndDate = endDate;
            ReservationDate = DateTime.Now;
            StatusId = RentStatusEnumeration.Pending.Id;
        }

        public void Start() => Status = RentStatusEnumeration.Active;

        public void Accept() => Status = RentStatusEnumeration.Approved;

        public void Cancel()
        {
            StatusId = RentStatusEnumeration.Canceled.Id;
            CancellationDate = DateTime.Now;
        }
    }
}
