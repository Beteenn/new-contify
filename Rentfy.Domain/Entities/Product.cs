using Rentfy.Domain.SeedWork;

namespace Rentfy.Domain.Entities
{
    public class Product : IItemCollection<Product>
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Amount { get; private set; }
        public int RentedAmount { get; private set; }
        public int FreeAmount => Amount - RentedAmount;
        public double HourValue { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategory Category { get; private set; }
        public Store Store { get; private set; }
        public long StoreId { get; private set; }

        public Product() { }

        public Product(string name, string description, int amount, int rentedAmount, double hourValue, long categoryId)
        {
            Name = name;
            Description = description;
            Amount = amount;
            RentedAmount = rentedAmount;
            HourValue = hourValue;
            CategoryId = categoryId;
        }

        public Product(string name, string description, int amount, double hourValue, long categoryId, long storeId)
        {
            Name = name;
            Description = description;
            Amount = amount;
            HourValue = hourValue;
            CategoryId = categoryId;
            StoreId = storeId;
        }

        public Product(long id, string name, string description, int amount, int rentedAmount, double hourValue, long categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Amount = amount;
            RentedAmount = rentedAmount;
            HourValue = hourValue;
            CategoryId = categoryId;
        }

        public bool IsFreeToRent(int quantity = 1) => FreeAmount >= quantity;

        public void UpdateBasicInfo(Product productUpdate)
        {
            Name = productUpdate.Name;
            Description = productUpdate.Description;
            Amount = productUpdate.Amount;
            HourValue = productUpdate.HourValue;
            CategoryId = productUpdate.CategoryId;
            StoreId = productUpdate.StoreId;
        }

        public void UpdateItem(Product item)
        {
            Name = item.Name;
            Description = item.Description;
            Amount = item.Amount;
            HourValue = item.HourValue;
            CategoryId = item.CategoryId;
        }

        public bool Equals(Product other) => Id == other.Id;

    }
}
