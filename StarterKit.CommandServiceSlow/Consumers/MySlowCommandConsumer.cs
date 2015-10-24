namespace StarterKit.CommandServiceSlow.Consumer
{
    using System;
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;

    public class MySlowCommandConsumer : IConsumer<MyCommand>
    {
        public async Task Consume(ConsumeContext<MyCommand> context)
        {
            System.Threading.Thread.Sleep(500);
            Console.Out.WriteLine("Received Command: " + context.Message.Message);
        }
    }
}
