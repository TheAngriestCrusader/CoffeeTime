using CoffeeTime.Main.ViewModels;
using System;
using CoffeeTime.Main.States;
using CoffeeTime.Main.Views;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeTime.Main
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
            services.AddSingleton<SplashScreenViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
