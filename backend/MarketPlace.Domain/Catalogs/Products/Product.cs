namespace MarketPlace.Domain.Catalogs.Products;

public class Product
{
    public Guid Id { get; }
    public String Name { get; }
    public String Description { get; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; }
   
    public Product(Guid id, String name, String description, DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Name = name;
        Description = description;  
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}
