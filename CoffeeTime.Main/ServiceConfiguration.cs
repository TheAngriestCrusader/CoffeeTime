using CoffeeTime.Main.ViewModels;
using System;
using CoffeeTime.Main.States;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeTime.Main
{
    public static class ServiceConfiguration
    {
        public static IServiceProvider ConfigureServices()
        {
            ServiceCollection services = new();
            services.AddSingleton<HeaderState>();
            services.AddSingleton<MainWindowViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
