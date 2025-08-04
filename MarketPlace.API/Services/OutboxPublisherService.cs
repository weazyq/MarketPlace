using MarketPlace.API.Kafka.Producer;
using MarketPlace.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.API.Services;

public class OutboxPublisherService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<OutboxPublisherService> _logger;
    private readonly TimeSpan _delay = TimeSpan.FromSeconds(20);

    public OutboxPublisherService(IServiceScopeFactory scopeFactory, ILogger<OutboxPublisherService> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Outbox Publisher Service started.");
        while (!stoppingToken.IsCancellationRequested) 
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                var kafkaProducer = scope.ServiceProvider.GetRequiredService<IKafkaProducer>();

                List<OutboxMessage> eventsToProcess = await dbContext.OutboxMessages
                    .Where(m => !m.IsProcessed)
                    .OrderBy(m => m.OccurredOn)
                    .Take(20)
                    .ToListAsync(stoppingToken);

                foreach (OutboxMessage outboxEvent in eventsToProcess)
                {
                    try
                    {
                        await kafkaProducer.ProduceAsync(outboxEvent.Type, outboxEvent.Payload);

                        outboxEvent.IsProcessed = true;
                        outboxEvent.ProcessedAt = DateTime.UtcNow;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error publishing event {EventId}", outboxEvent.Id);
                    }
                }

                await dbContext.SaveChangesAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Outbox Publisher Service");
            }

            await Task.Delay(_delay, stoppingToken);
        }
    }
}
