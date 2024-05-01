using MassTransit;
using MICROSERVICEARCH.Application.Domain.Options;
using Microsoft.Extensions.Options;

namespace MICROSERVICEARCH.Application.Messaging.Producer
{
    public class SampleSendProducer(ISendEndpointProvider sendEndpointProvider, IOptions<MessagingOptions> messagingOptions)
    {
        public async Task Send<T>(T message) where T : class
        {
            var endpoint = await sendEndpointProvider.GetSendEndpoint(new Uri(messagingOptions.Value.SendEndpointUri!));
            await endpoint.Send(message);
        }
    }
}
