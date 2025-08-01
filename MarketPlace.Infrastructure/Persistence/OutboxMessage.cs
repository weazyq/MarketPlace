namespace MarketPlace.Infrastructure.Persistence;

public class OutboxMessage
{
    public Guid Id { get; set; }
    public DateTime OccurredOn { get; set; }
    public required String Type { get; set; }
    public required String Payload { get; set; }
    public Boolean IsProcessed { get; set; }
    public DateTime? ProcessedAt { get; set; }
}
