namespace Rentfy.Domain.Entities
{
    public class Product
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

        public Product(string name, string description, int amount, double hourValue, long categoryId)
        {
            Name = name;
            Description = description;
            Amount = amount;
            HourValue = hourValue;
            CategoryId = categoryId;
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
        }
    }
}
