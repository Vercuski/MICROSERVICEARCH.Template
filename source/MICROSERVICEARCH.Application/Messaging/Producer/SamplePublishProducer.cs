using MassTransit;

namespace MICROSERVICEARCH.Application.Messaging.Producer
{
    public class SamplePublishProducer(IPublishEndpoint publishEndpoint)
    {
        public async Task Publish<T>(T message) where T : class
        {
            await publishEndpoint.Publish(message);
        }
    }
}
