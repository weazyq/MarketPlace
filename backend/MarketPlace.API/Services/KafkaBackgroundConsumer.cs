using Confluent.Kafka;
using MarketPlace.API.Kafka.Consumer;
using Newtonsoft.Json;

namespace MarketPlace.API.Services;

public class KafkaBackgroundConsumer<TMessage> : BackgroundService
{
    private readonly ILogger<KafkaBackgroundConsumer<TMessage>> _logger;
    private readonly IConsumer<Ignore, String> _consumer;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly String _topic;

    public KafkaBackgroundConsumer(
        ILogger<KafkaBackgroundConsumer<TMessage>> logger, 
        IServiceScopeFactory scopeFactory,
        IConfiguration configuration)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;

        ConsumerConfig config = new ConsumerConfig
        {
            BootstrapServers = configuration["Kafka:BootstrapServers"],
            GroupId = $"consumer-{typeof(TMessage).Name.ToLower()}",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        _consumer = new ConsumerBuilder<Ignore, String>(config).Build();
        _topic = typeof(TMessage).Name;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _consumer.Subscribe(_topic);
        _logger.LogInformation("Kafka consumer started for topic: {Topic}", _topic);

        await Task.Run(async() =>
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var result = _consumer.Consume(stoppingToken);
                    var json = result.Message.Value;

                    using var scope = _scopeFactory.CreateScope();
                    var handler = scope.ServiceProvider.GetRequiredService<IKafkaConsumer<TMessage>>();

                    var message = JsonConvert.DeserializeObject<TMessage>(json);
                    if (message is not null)
                    {
                        await handler.HandleAsync(message, stoppingToken);
                    }
                }
                catch (ConsumeException ex)
                {
                    _logger.LogError(ex, "❌ Kafka consume error");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "❌ Unexpected error in consumer");
                }
            }
        }, stoppingToken);
    }

    public override void Dispose()
    {
        _consumer.Close();
        _consumer.Dispose();
        base.Dispose();
    }
}
