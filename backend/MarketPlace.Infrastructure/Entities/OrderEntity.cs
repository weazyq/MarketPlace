using MarketPlace.Domain.Orders;

namespace MarketPlace.Infrastructure.Entities;

public class OrderEntity
{
    public Guid Id { get; set; }
    public OrderState State { get; set; }
    public Decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    public UserEntity User { get; set; }
}
