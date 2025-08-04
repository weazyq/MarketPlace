
using Confluent.Kafka;

namespace MarketPlace.API.Kafka.Producer;

public class KafkaProducer : IKafkaProducer
{
    private readonly IProducer<Null, string> _producer;

    public KafkaProducer(IConfiguration configuration)
    {
        ProducerConfig producerConfig = new ProducerConfig
        {
            BootstrapServers = configuration["Kafka:BootstrapServers"]
        };
        _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
    }

    public async Task ProduceAsync(string topic, string message)
    {
        var result = await _producer.ProduceAsync(topic, new Message<Null, string>
        {
            Value = message
        });
    }
}
