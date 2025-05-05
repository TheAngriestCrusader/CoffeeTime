using CoffeeTime.Main.ViewModels;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeTime.Main
{
    public static class ServiceConfiguration
    {
        public static IServiceProvider ConfigureServices()
        {
            ServiceCollection services = new();
            services.AddSingleton<MainWindowViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
