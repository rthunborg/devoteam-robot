using DevoRobot.Application;
using DevoRobot.Application.Interfaces;
using DevoRobot.Infrastructure;
using DevoRobot.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScoped<IRobotApp, RobotApp>();
        services.AddScoped<IRobotService, RobotService>();
    })
    .Build();

using var scope = host.Services.CreateScope();
var app = scope.ServiceProvider.GetRequiredService<IRobotApp>();
app.Run();
