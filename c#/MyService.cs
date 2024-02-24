using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

namespace c_;
public class MyService : IHostedService
{
    public MyService(ILogger<MyService> logger, IDoSomething doSomething)
    {
        Logger = logger;
        DoSomething = doSomething;
    }

    private ILogger Logger { get; }
    private IDoSomething DoSomething { get; }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Logger.LogInformation("Started at {Now}", DateTime.Now);
        DoSomething.DoIt("purple");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Logger.LogInformation("Done");
        return Task.CompletedTask;
    }
}
