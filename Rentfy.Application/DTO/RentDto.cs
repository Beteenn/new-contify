using System;

namespace Rentfy.Application.DTO
{
    public class RentDto
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long StoreId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime CancellationDate { get; set; }
        public long TotalValue { get; set; }
        public int StatusId { get; set; }
    }
}
