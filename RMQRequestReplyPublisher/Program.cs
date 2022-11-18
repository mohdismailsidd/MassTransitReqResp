// See https://aka.ms/new-console-template for more information
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReqResp.Abstraction.Interface;
using ReqResp.Abstraction.Models;

Console.WriteLine("Publisher Started...");

var builder = new HostBuilder()
    .ConfigureServices(services =>
        services.AddMassTransit(config =>
        {
            config.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(new Uri("rabbitmq://localhost:5672/"), settings =>
                {
                    settings.Username("guest");
                    settings.Password("guest");
                    settings.Heartbeat(30);
                });
            });
            config.AddRequestClient<ISimpleRequest>();
        }))
.Build();

var _busControl = builder.Services.GetRequiredService<IBusControl>();
var _client = _busControl.CreateRequestClient<ISimpleRequest>(new Uri("queue:request_service"));

while (true)
{
    Console.WriteLine("Enter message (or quit to exit)");
    Console.Write("> ");
    var value = Console.ReadLine();


    if ("quit".Equals(value, StringComparison.OrdinalIgnoreCase))
        break;

    Response<ISimpleResponse> response = null;
    try
    {
        response = await _client.GetResponse<ISimpleResponse>(new SimpleRequest(value));
    }
    catch (Exception ex)
    {
        Console.WriteLine("No Response Recived." + ex.Message);
    }
    Console.WriteLine("Response from the client: " + response?.Message?.CusomerName);
}
Console.ReadLine();