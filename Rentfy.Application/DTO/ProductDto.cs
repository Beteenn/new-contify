namespace Rentfy.Application.DTO
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public double HourValue { get; set; }
        public long CategoryId { get; set; }
    }
}
