using MarketPlace.Domain.Events.Interface;

namespace MarketPlace.Domain.Events;

public class ProductAddedEvent : IDomainEvent
{
    public Guid ProductId { get; }
    public String Name { get; }
    public DateTime OccurredOn { get; }

    public ProductAddedEvent(Guid productId, String name, DateTime createdAt)
    {
        ProductId = productId;
        Name = name;
        OccurredOn = createdAt;
    }
}
