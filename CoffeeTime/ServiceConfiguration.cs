using System;
using Microsoft.Extensions.DependencyInjection;
using CoffeeTime.States;
using CoffeeTime.Services;
using CoffeeTime.ViewModels;

namespace CoffeeTime
{
    public static class ServiceConfiguration
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //  Application-wide states
            services.AddSingleton<EndpointState>();
            services.AddSingleton<HeaderState>();
            services.AddSingleton<MainDisplayState>();
            
            services.AddSingleton<IViewModelFactoryService, ViewModelFactoryService>();
            services.AddSingleton<INavigationService, NavigationService>();

            //  Auto-register all ViewModels in this assembly as transient
            services.Scan(scan => scan
                .FromAssemblyOf<MainWindowViewModel>()
                .AddClasses(classes => classes.AssignableTo<ViewModelBase>())
                .AsSelf()
                .WithTransientLifetime());

            return services.BuildServiceProvider();
        }
    }
}