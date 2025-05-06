using System;
using CoffeeTime.Services;
using CoffeeTime.States;
using CoffeeTime.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeTime;

public static class ServiceConfiguration
{
    public static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        //  Application-wide states
        services.AddSingleton<EndpointState>();
        services.AddSingleton<HeaderState>();
        services.AddSingleton<MainDisplayState>();

        services.AddSingleton<IModuleViewModelFactoryService, ModuleModuleViewModelFactoryService>();
        services.AddSingleton<IMetricsPollingService, MetricsPollingService>();
        services.AddSingleton<IModuleNavigationService, ModuleNavigationService>();

        //  Auto-register all ViewModels in this assembly as transient
        services.Scan(scan => scan
            .FromAssemblyOf<MainWindowViewModel>()
            .AddClasses(classes => classes.AssignableTo<ViewModelBase>())
            .AsSelf()
            .WithTransientLifetime());

        return services.BuildServiceProvider();
    }
}