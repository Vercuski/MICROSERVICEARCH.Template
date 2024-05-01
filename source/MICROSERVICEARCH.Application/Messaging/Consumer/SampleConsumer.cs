using MassTransit;

namespace MICROSERVICEARCH.Application.Messaging.Consumer
{
    public class SampleConsumer<T> : IConsumer<T> where T : class
    {
        public async Task Consume(ConsumeContext<T> context)
        {
            await Task.Delay(1);
        }
    }
}
