namespace StarterKit.EventService.Consumer
{
    using System;
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;

    public class MyEventConsumer : IConsumer<MyEvent>
    {
        public Task Consume(ConsumeContext<MyEvent> context)
        {
            Console.Out.WriteLine("Received Event: " + context.Message.Message);
            return Task.FromResult(0);
        }
    }
}
