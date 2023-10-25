using Microsoft.Extensions.Hosting;
using FunRunUs.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using FunRunUs.Spell;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    await services.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

IHostBuilder CreateHostBuilder(string[] strings)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddRepositoryDependencies();
            services.AddSingleton<App>();
        });
}
