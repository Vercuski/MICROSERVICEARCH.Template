using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MICROSERVICEARCH.Messaging.Consumer
{
    public class SampleConsumer<T> : IConsumer<T> where T : class
    {
        public async Task Consume(ConsumeContext<T> context)
        {
            await Task.Delay(1);
        }
    }
}
