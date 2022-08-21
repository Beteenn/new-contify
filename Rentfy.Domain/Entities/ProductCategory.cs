namespace Rentfy.Domain.Entities
{
    public class ProductCategory
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        // TODO: Adicionar store

        public ProductCategory() { }

        public ProductCategory(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public ProductCategory(string name)
        {
            Name = name;
        }

        public void UpdateName(string name) => Name = name;
    }
}
