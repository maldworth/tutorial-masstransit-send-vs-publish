namespace StarterKit.BusModule
{
    using System;
    using System.Configuration;
    using Autofac;
    using MassTransit;
    using MassTransit.RabbitMqTransport;

    public class BusModule : Module
    {
        private readonly System.Reflection.Assembly[] _assembliesToScan;
        private readonly Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost, IComponentContext> _moreBusInitialization;

        public BusModule(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost, IComponentContext> moreBusInitialization = null, params System.Reflection.Assembly[] assembliesToScan)
        {
            _moreBusInitialization = moreBusInitialization;
            _assembliesToScan = assembliesToScan;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // Registers all consumers with our container
            builder.RegisterConsumers(_assembliesToScan);

            // Creates our bus from the factory and registers it as a singleton against two interfaces
            builder.Register(c => Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var componentContext = c.Resolve<IComponentContext>();

                var host = sbc.Host(new Uri(ConfigurationManager.AppSettings["RabbitMQHost"]), h =>
                {
                    // Configure your host
                    h.Username("starterkit");
                    h.Password("banana");
                });

                _moreBusInitialization(sbc, host, componentContext);

                //sbc.ReceiveEndpoint(host, "my_events", e =>
                //{
                //    // Configure your consumer(s)
                //    e.PrefetchCount = 1;
                //    e.LoadFrom(componentContext.Resolve<ILifetimeScope>());
                //});
            }))
                .SingleInstance()
                .As<IBusControl>()
                .As<IBus>();
        }
    }
}
