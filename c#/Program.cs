using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace c_;

class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("my log.log")
            .CreateBootstrapLogger();
        Console.WriteLine("Hello, World!");
        var builder = Host.CreateDefaultBuilder();
        builder.ConfigureServices(services =>
        {
            services.AddSingleton<IDoSomething, DoSomething>();
            services.AddHostedService<MyService>();
        });
        builder.UseSerilog();
        builder.UseWindowsService(options => options.ServiceName = "Bob Service");
        builder.Build().Run();
    }
}
