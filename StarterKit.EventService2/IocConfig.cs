namespace StarterKit.EventService
{
    using System.Reflection;
    using Autofac;
    using BusModule;
    using MassTransit;
    using MassTransit.RabbitMqTransport;
    using StarterKit.EventService.Consumer;

    public class IocConfig
    {
        public static IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MyService>();

            builder.RegisterModule(new BusModule(Assembly.GetExecutingAssembly()));

            return builder.Build();
        }
    }
}
