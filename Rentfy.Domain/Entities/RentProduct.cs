using Rentfy.Domain.SeedWork;

namespace Rentfy.Domain.Entities
{
    public class RentProduct : IItemCollection<RentProduct>
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double HourValue { get; private set; }
        public string CategoryName { get; private set; }
        public Store Store { get; private set; }
        public long StoreId { get; private set; }

        public RentProduct() { }

        public RentProduct(string name, string description, double hourValue, string categoryName)
        {
            Name = name;
            Description = description;
            HourValue = hourValue;
            CategoryName = categoryName;
        }

        public RentProduct(string name, string description, double hourValue, string categoryName, long storeId)
        {
            Name = name;
            Description = description;
            HourValue = hourValue;
            CategoryName = categoryName;
            StoreId = storeId;
        }

        public RentProduct(long id, string name, string description, double hourValue, string categoryName)
        {
            Id = id;
            Name = name;
            Description = description;
            HourValue = hourValue;
            CategoryName = categoryName;
        }

        public void UpdateBasicInfo(RentProduct productUpdate)
        {
            Name = productUpdate.Name;
            Description = productUpdate.Description;
            HourValue = productUpdate.HourValue;
            CategoryName = productUpdate.CategoryName;
            StoreId = productUpdate.StoreId;
        }

        public void UpdateItem(RentProduct item)
        {
            Name = item.Name;
            Description = item.Description;
            HourValue = item.HourValue;
            CategoryName = item.CategoryName;
        }

        public bool Equals(RentProduct other) => Name == other.Name && HourValue == other.HourValue;

    }
}
