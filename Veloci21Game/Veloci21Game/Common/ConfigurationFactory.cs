using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Serilog;

namespace Veloci21Game.Common;

public static class ConfigurationFactory
{
    public static IConfigurationRoot Get()
    {
        var configurationRoot = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile($"{GetAssemblyShortName()}.json", true, true)
            .AddJsonFile(Environment.GetEnvironmentVariable("SETTINGS_PATH") ?? "settings.json", true, true)
            .Build();
        return configurationRoot;
    }

    private static string GetAssemblyShortName()
    {
        var assemblyName = Assembly.GetEntryAssembly()?.GetName().Name?.Split('.').LastOrDefault();
        return string.IsNullOrWhiteSpace(assemblyName) ? "appsettings" : assemblyName.ToLowerInvariant();
    }

    public static void LogDebugConfigurationDebugView(IConfigurationRoot configurationRoot)
    {
        foreach (var fileConfigurationProvider in configurationRoot.Providers.OfType<JsonConfigurationProvider>())
            Log.Debug("Configuration Path: {Path}", fileConfigurationProvider.Source.Path);
        Log.Debug("GetDebugView: {@GetDebugView}", configurationRoot.GetDebugView());
    }
}