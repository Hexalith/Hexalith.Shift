using Hexalith.Shift.Service;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<MicrosoftShiftWorker>();
    })
    .Build();

await host.RunAsync();