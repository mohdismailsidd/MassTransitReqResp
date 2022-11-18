using MassTransit;
using Microsoft.Extensions.Hosting;
using ReqResp.Abstraction.Interface;
using ReqResp.Consumer;

Console.WriteLine("Consumer Started...");
var builder = new HostBuilder()
    .ConfigureServices(services => services.AddMassTransit(config =>
    {
        config.AddConsumer<RequestConsumer>();
        config.UsingRabbitMq((ctx, cfg) =>
        {
            cfg.Host(new Uri("rabbitmq://localhost:5672/"), settings =>
            {
                settings.Username("guest");
                settings.Password("guest");
            });
            cfg.ReceiveEndpoint("request_service", x => { x.ConfigureConsumers(ctx); });
        });
        config.AddRequestClient<ISimpleRequest>();
    }))
.Build();

builder.Run();