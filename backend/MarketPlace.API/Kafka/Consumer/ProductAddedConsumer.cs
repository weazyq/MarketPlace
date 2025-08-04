using MarketPlace.Domain.Events;

namespace MarketPlace.API.Kafka.Consumer;

public class ProductAddedConsumer : IKafkaConsumer<ProductAddedEvent>
{
    private readonly ILogger<ProductAddedConsumer> _logger;

    public ProductAddedConsumer(ILogger<ProductAddedConsumer> logger)
    {
        _logger = logger;
    }

    public Task HandleAsync(ProductAddedEvent message, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("📥 ProductCreated received: { @Message}", message);
        return Task.CompletedTask;
    }
}
