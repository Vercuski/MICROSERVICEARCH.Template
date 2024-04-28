﻿using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MICROSERVICEARCH.Messaging.Producer
{
    public class SamplePublishProducer(IPublishEndpoint publishEndpoint)
    {
        public async Task Publish<T>(T message) where T : class
        {
            await publishEndpoint.Publish(message);
        }
    }
}
