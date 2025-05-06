using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using CoffeeTime.ViewModels;
using CoffeeTime.Views;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeTime;

public class App : Application
{
    static App()
    {
        Services = ServiceConfiguration.ConfigureServices();
    }

    private static IServiceProvider Services { get; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations
            DisableAvaloniaDataAnnotationValidation();

            // Resolve MainWindowViewModel via DI
            var mainVm = Services.GetRequiredService<MainWindowViewModel>();

            desktop.MainWindow = new MainWindow
            {
                DataContext = mainVm
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static void DisableAvaloniaDataAnnotationValidation()
    {
        var plugins = BindingPlugins.DataValidators
            .OfType<DataAnnotationsValidationPlugin>()
            .ToArray();
        foreach (var plugin in plugins)
            BindingPlugins.DataValidators.Remove(plugin);
    }
}