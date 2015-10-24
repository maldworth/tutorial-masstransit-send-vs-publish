namespace StarterKit.CommandServiceFast.Consumer
{
    using System;
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;

    public class MyFastCommandConsumer : IConsumer<MyCommand>
    {
        public async Task Consume(ConsumeContext<MyCommand> context)
        {
            System.Threading.Thread.Sleep(200);
            Console.Out.WriteLine("Received Command: " + context.Message.Message);
        }
    }
}
