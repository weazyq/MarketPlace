using MarketPlace.Domain.Events;
using MarketPlace.Domain.Events.Interface;

namespace MarketPlace.Infrastructure.Entities;

public class ProductEntity
{
    public Guid Id { get; set; }
    public required String Name { get; set; }
    public required String Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Boolean IsRemoved { get; set; }
    
    private readonly List<IDomainEvent> _productEvents = new();
    public IReadOnlyCollection<IDomainEvent> Events => _productEvents.AsReadOnly();

    public void AddEvent(IDomainEvent @event)
    {
        _productEvents.Add(@event);
    }
}
