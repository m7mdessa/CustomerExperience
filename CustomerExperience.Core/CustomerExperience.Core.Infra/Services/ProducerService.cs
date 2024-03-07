using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace CustomerExperience.Core.Infra.Services
{
    using Polly;
    using Polly.CircuitBreaker;
    using Polly.Wrap;
    using Confluent.Kafka;

    public class ProducerService
    {
        private readonly IConfiguration _configuration;
        private readonly IProducer<Null, string> _producer;

        private readonly AsyncPolicyWrap _fallbackPolicyWrap;
        private readonly AsyncPolicy<string> _fallbackPolicy;
        public ProducerService(IConfiguration configuration)
        {
            _configuration = configuration;

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = _configuration["MessageBroker:Host"]
            };

            _producer = new ProducerBuilder<Null, string>(producerConfig).Build();

            // Configure Polly fallback policy
            _fallbackPolicy = Policy<string>
                .Handle<ProduceException<Null, string>>()
                .FallbackAsync("Fallback message");
        }

        public async Task ProduceAsync(string topic, string message)
        {
            await _fallbackPolicyWrap.ExecuteAsync(async () =>
            {
                var kafkaMessage = new Message<Null, string>
                {
                    Value = message,
                };

                await _producer.ProduceAsync(topic, kafkaMessage);
            });
        }
    }

}
