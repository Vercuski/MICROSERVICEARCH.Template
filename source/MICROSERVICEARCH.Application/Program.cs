using MICROSERVICEARCH.Application;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder();
var host = builder
    .AddApplicationRegistration()
    .Build();

host.Run();