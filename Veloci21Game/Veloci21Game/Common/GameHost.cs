using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Veloci21Game.Common;

public class GameHost : BackgroundService, IHostedService
{
    public GameHost(ILogger<GameHost> logger, IHostApplicationLifetime hostApplicationLifetime, IGame game)
    {
        Logger = logger;
        Game = game;

        hostApplicationLifetime.ApplicationStarted.Register(OnStarted);
        hostApplicationLifetime.ApplicationStopping.Register(OnStopping);
        hostApplicationLifetime.ApplicationStopped.Register(OnStopped);
    }

    private ILogger Logger { get; }
    private IGame Game { get; }

    private void OnStarted()
    {
        Logger.LogDebug("OnStarted()");
    }

    private void OnStopping()
    {
        Logger.LogDebug("OnStopping()");
    }

    private void OnStopped()
    {
        Logger.LogDebug("OnStopped()");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();
        Logger.LogDebug("ExecuteAsync()");
        try
        {
            await Game.Play().ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            Logger.LogCritical(exception, "Failed to start.");
        }
    }
}