using MICROARCH.Messaging;
using MICROSERVICEARCH.Application;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder();
var host = builder
    .AddApplicationRegistration()
    .AddMessagingRegistration()
    .Build();

host.Run();