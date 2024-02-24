using System.Reflection;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Veloci21Game.Common;

public static class SerilogConfiguration
{
    public static void ConfigureSerilog(IConfigurationRoot configurationRoot)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configurationRoot)
            .Enrich.WithThreadId()
            .Enrich.WithProcessId()
            .Enrich.FromLogContext()
            .CreateLogger();
        LogAssemblyInfo();
    }

    private static void LogAssemblyInfo()
    {
        var entryAssembly = Assembly.GetEntryAssembly();
        Log.Information(@"

 /$$    /$$          /$$                     /$$  /$$$$$$    /$$          /$$$$$$                                   
| $$   | $$         | $$                    |__/ /$$__  $$ /$$$$         /$$__  $$                                  
| $$   | $$ /$$$$$$ | $$  /$$$$$$   /$$$$$$$ /$$|__/  \ $$|_  $$        | $$  \__/  /$$$$$$  /$$$$$$/$$$$   /$$$$$$ 
|  $$ / $$//$$__  $$| $$ /$$__  $$ /$$_____/| $$  /$$$$$$/  | $$        | $$ /$$$$ |____  $$| $$_  $$_  $$ /$$__  $$
 \  $$ $$/| $$$$$$$$| $$| $$  \ $$| $$      | $$ /$$____/   | $$        | $$|_  $$  /$$$$$$$| $$ \ $$ \ $$| $$$$$$$$
  \  $$$/ | $$_____/| $$| $$  | $$| $$      | $$| $$        | $$        | $$  \ $$ /$$__  $$| $$ | $$ | $$| $$_____/
   \  $/  |  $$$$$$$| $$|  $$$$$$/|  $$$$$$$| $$| $$$$$$$$ /$$$$$$      |  $$$$$$/|  $$$$$$$| $$ | $$ | $$|  $$$$$$$
    \_/    \_______/|__/ \______/  \_______/|__/|________/|______/       \______/  \_______/|__/ |__/ |__/ \_______/
");
        Log.Information(entryAssembly?.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description!);
        Log.Information(entryAssembly?.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright!);
    }
}