namespace MarketPlace.API.Kafka.Producer;

public interface IKafkaProducer
{
    Task ProduceAsync(string topic, string message);
}
