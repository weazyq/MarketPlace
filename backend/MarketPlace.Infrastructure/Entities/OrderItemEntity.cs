namespace MarketPlace.Infrastructure.Entities;

public class OrderItemEntity
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public Guid ProductId { get; set; }
    public Guid OrderId { get; set; }
}
