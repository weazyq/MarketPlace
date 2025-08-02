
using MarketPlace.Infrastructure.Persistence;

namespace MarketPlace.API.Services;

public class OutboxPublisherService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<OutboxPublisherService> _logger;
    private readonly TimeSpan _delay = TimeSpan.FromSeconds(5);

    public OutboxPublisherService(IServiceScopeFactory scopeFactory, ILogger<OutboxPublisherService> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Outbox Publisher Service started.");

        while (stoppingToken.IsCancellationRequested) 
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                var kafkaProducer = scope.ServiceProvider.GetRequiredService<IKafkaProducer>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Outbox Publisher Service");
            }

            await Task.Delay(_delay, stoppingToken);
        }
    }
}
