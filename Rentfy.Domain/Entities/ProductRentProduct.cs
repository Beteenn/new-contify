namespace Rentfy.Domain.Entities
{
    public class ProductRentProduct
    {
        public long Id { get; private set; }
        public long ProductRentId { get; private set; }
        public RentProduct ProductRent { get; private set; }
        public long RentId { get; private set; }
        public Rent Rent { get; private set; }

        public ProductRentProduct() { }

        public ProductRentProduct(long id, long productId, long rentId)
        {
            Id = id;
            ProductRentId = productId;
            RentId = rentId;
        }

        public ProductRentProduct(long productId, long rentId)
        {
            ProductRentId = productId;
            RentId = rentId;
        }
    }
}
