namespace MarketPlace.Infrastructure.Entities;

public class ProductEntity
{
    public Guid Id { get; set; }
    public required String Name { get; set; }
    public required String Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Boolean IsRemoved { get; set; }
}
