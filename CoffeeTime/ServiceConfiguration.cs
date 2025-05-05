using System;
using CoffeeTime.Views;
using CoffeeTime.States;
using CoffeeTime.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeTime
{
    public static class ServiceConfiguration
    {
        public static IServiceProvider ConfigureServices()
        {
            ServiceCollection services = new();
            
            // States
            services.AddSingleton<HeaderState>();
            services.AddSingleton<MainDisplayState>();
            
            // View Models
            services.AddSingleton<MainWindowViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
