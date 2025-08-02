namespace MarketPlace.API.Kafka;

public interface IKafkaProducer
{
    Task ProduceAsync(string topic, string message);
}
