using DevoRobot.Application;
using DevoRobot.Application.Interfaces;
using DevoRobot.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddScoped<IRobotApp, RobotApp>();
        services.AddScoped<RobotService>();
    })
    .Build();

using var scope = host.Services.CreateScope();
var app = scope.ServiceProvider.GetRequiredService<IRobotApp>();
app.Run();
