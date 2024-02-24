using Microsoft.Extensions.Logging;

namespace c_;

public class DoSomething : IDoSomething
{
    public DoSomething(ILogger<DoSomething> logger)
    {
        Logger = logger;
    }

    private ILogger Logger { get; }
    public void DoIt(string message)
    {
        Logger.LogInformation("DoIt(message: {message})", message);
    }
}