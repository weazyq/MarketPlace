using MarketPlace.Domain.Events.Interface;

namespace MarketPlace.Infrastructure.Entities;

public class ProductEntity : IHasDomainEvents
{
    public Guid Id { get; set; }
    public Guid ShopID { get; set; }
    public required String Name { get; set; }
    public required String Description { get; set; }
    public Decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public float Rating { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Boolean IsRemoved { get; set; }

    private readonly List<IDomainEvent> _productEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _productEvents.AsReadOnly();

    public void AddEvent(IDomainEvent @event)
    {
        _productEvents.Add(@event);
    }

    public void ClearDomainEvents()
    {
        _productEvents.Clear();
    }
}
