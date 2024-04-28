using MassTransit;
using MassTransit.Configuration;
using MICROSERVICEARCH.Domain.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MICROSERVICEARCH.Messaging.Producer
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
