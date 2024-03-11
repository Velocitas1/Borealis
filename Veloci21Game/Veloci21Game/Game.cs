using Microsoft.Extensions.Logging;
using Veloci21Game.Common;

namespace Veloci21Game;

public class Game(ILogger<Game> logger) : IGame
{
    private ILogger Logger { get; } = logger;

    public Task Play()
    {
        Logger.LogInformation("Gee, some fun this is.");
        GetPlayers();
        return Task.CompletedTask;
    }

    private void GetPlayers()
    {
        Player1 = GetPlayer();
    }

    private Player GetPlayer()
    {
        Logger.LogInformation("Enter Player 1 Name:");
        var name = Console.ReadLine();
        return new
    }

    public Player Player1 { get; set; }
}

public class Player
{
}