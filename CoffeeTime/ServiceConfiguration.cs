using System;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using CoffeeTime.States;
using CoffeeTime.Modules.EndpointInfo.ViewModels;
using CoffeeTime.Services;
using CoffeeTime.ViewModels;

namespace CoffeeTime
{
    public static class ServiceConfiguration
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //  1. Application-wide state (singletons)
            services.AddSingleton<EndpointInfoState>();
            services.AddSingleton<HeaderState>();
            services.AddSingleton<MainDisplayState>();

            //  2. Core services
            //      services.AddSingleton<ISystemMetricsService, SystemMetricsService>();

            //  3. Navigation and factories
            services.AddSingleton<IViewModelFactoryService, ViewModelFactoryService>();
            services.AddSingleton<INavigationService, NavigationService>();

            //  4. Auto-register all ViewModels in this assembly as transient
            services.Scan(scan => scan
                .FromAssemblyOf<MainWindowViewModel>()
                .AddClasses(classes => classes.AssignableTo<ViewModelBase>())
                .AsSelf()
                .WithTransientLifetime());

            //  5. Register any other utilities, logging, config, etc.
            //      services.AddLogging();
            //      services.AddOptions<YourOptions>();

            return services.BuildServiceProvider();
        }
    }
}