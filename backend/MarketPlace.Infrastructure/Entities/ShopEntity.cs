namespace MarketPlace.Infrastructure.Entities;

public class ShopEntity
{
    public Guid Id { get; set; }
    public String Name { get; set; } = String.Empty;
    public String JuridicalName { get; set; } = String.Empty;
    public String Description { get; set; } = String.Empty;
    public DateTime CreatedAt { get; set; }
}
