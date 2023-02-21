using BoardGame;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.NetworkInformation;


using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IBoard, Board>();
        services.AddSingleton<Game>();
        services.AddTransient<IPlayer, Player>();

    })
.Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;
Game game = provider.GetRequiredService<Game>();
game.StartGame();

await host.RunAsync();