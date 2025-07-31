namespace MarketPlace.Domain.Catalogs.Product
{
    public class ProductBlank
    {
        public Guid Id { get; set; } = Guid.Empty;
        public String Name { get; set; } = String.Empty;
        public String Description { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
