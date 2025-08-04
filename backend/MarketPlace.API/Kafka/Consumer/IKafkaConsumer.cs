namespace MarketPlace.API.Kafka.Consumer;

public interface IKafkaConsumer<T>
{
    Task HandleAsync(T message, CancellationToken cancellationToken = default);
}
