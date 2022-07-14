namespace Rentfy.Application.ViewModels
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int RentedAmount { get; set; }
        public int FreeAmount { get; set; }
        public double HourValue { get; set; }
        public ProductCategoryViewModel Category { get; set; }
        public StoreViewModel Store { get; set; }
    }
}
