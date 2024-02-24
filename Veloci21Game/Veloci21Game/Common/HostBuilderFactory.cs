using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Veloci21Game.Common;

public static class HostBuilderFactory
{
    public static string AddLindy(this string input, string req, string andThisPerson = null)
    {
        return input + " Lindy" + req + andThisPerson;
    }
    public static IHostBuilder CreateHostBuilder(string[] args, Action<ContainerBuilder> configurationAction,
        IConfigurationRoot configurationRoot, Action<HostBuilderContext, IServiceCollection> configureDelegate = null)
    {
        var example = "Kelly".AddLindy(";-)"," John");
        example = example.AddLindy(":-)");
        example = AddLindy(example, "<3" ," Matthew");
        Log.Information("example: {example}", example);
        Log.Debug("CreateHostBuilder(args: {@args})", args);
        var hostBuilder = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(builder => builder.AddConfiguration(configurationRoot))
            .UseContentRoot(AppContext.BaseDirectory)
            .UseSerilog()
            .UseServiceProviderFactory(new AutofacServiceProviderFactory(configurationAction));
        if (configureDelegate != null)
            hostBuilder.ConfigureServices(configureDelegate);
        Log.Debug("UserInteractive: {UserInteractive}", Environment.UserInteractive);
        if (Environment.UserInteractive && !args.Contains("--run-as-service"))
        {
            Log.Debug("Detected Console Context");
            hostBuilder.UseConsoleLifetime();
        }
        else
        {
            Log.Debug("Detected Windows Service Context");
            hostBuilder.UseWindowsService();
        }

        return hostBuilder;
    }
}