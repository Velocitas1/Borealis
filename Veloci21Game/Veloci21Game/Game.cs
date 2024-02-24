using Microsoft.Extensions.Logging;
using Veloci21Game.Common;

namespace Veloci21Game;

public class Game(ILogger<Game> logger) : IGame
{
    private ILogger Logger { get; } = logger;

    public Task Play()
    {
        Logger.LogInformation("Gee, some fun this is.");
        return Task.CompletedTask;
    }
}