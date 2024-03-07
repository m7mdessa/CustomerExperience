using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.CircuitBreaker;
using Polly.Wrap;
using Confluent.Kafka;
namespace CustomerExperience.Core.Infra.Services
{


    public class ProducerService
    {
        private readonly IConfiguration _configuration;
        private readonly IProducer<Null, string> _producer;

        private readonly AsyncPolicyWrap<string> _fallbackPolicyWrap;

        public ProducerService(IConfiguration configuration)
        {
            _configuration = configuration;

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = _configuration["MessageBroker:Host"]
            };

            _producer = new ProducerBuilder<Null, string>(producerConfig).Build();

            // Configure Polly fallback policy with a generic result type
            var fallbackPolicy = Policy<string>
                .Handle<ProduceException<Null, string>>()
                .FallbackAsync("Fallback message");

            _fallbackPolicyWrap = fallbackPolicy.WrapAsync(fallbackPolicy);
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

                // Return a placeholder value or any other relevant value
                return "Success";
            });
        }
    }


}
