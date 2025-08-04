using MarketPlace.Domain.Events.Interface;

namespace MarketPlace.Infrastructure.Entities;

internal interface IHasDomainEvents
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
}
