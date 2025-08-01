namespace MarketPlace.Domain.Events.Interface;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
