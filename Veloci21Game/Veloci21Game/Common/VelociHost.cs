using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Veloci21Game.Common;

public static class VelociHost
{
    public static async Task RunAsync(string[] args, Action<ContainerBuilder> configurationAction,
        Action<HostBuilderContext, IServiceCollection> configureDelegate = null)
    {
        var configurationRoot = ConfigurationFactory.Get();
        SerilogConfiguration.ConfigureSerilog(configurationRoot);
        Log.Debug("RunAsync(args: {@args})", args);
        ConfigurationFactory.LogDebugConfigurationDebugView(configurationRoot);
        try
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            var host = HostBuilderFactory
                .CreateHostBuilder(args, configurationAction, configurationRoot, configureDelegate)
                .Build();
            await host.RunAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException operationCanceledException)
        {
            Log.Information(operationCanceledException, "VelociHost Stopping");
        }
        catch (Exception exception)
        {
            Log.Fatal(exception, "{Name} terminated unexpectedly", Assembly.GetEntryAssembly()?.GetName().Name);
        }
        finally
        {
            Log.Debug("RunAsync Finished");
            await Log.CloseAndFlushAsync().ConfigureAwait(false);
        }
    }
}