using Autofac;
using Veloci21Game.Common;

namespace Veloci21Game;

public static class Program
{
    public static async Task Main(string[] args)
    {
        await VelociHost.RunAsync(args, ConfigurationAction).ConfigureAwait(false);
    }

    private static void ConfigurationAction(ContainerBuilder containerBuilder)
    {
        containerBuilder.RegisterType<Game>().AsImplementedInterfaces().SingleInstance();
        containerBuilder.RegisterType<GameHost>().AsImplementedInterfaces().SingleInstance();
    }
}