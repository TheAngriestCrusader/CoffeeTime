using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using CoffeeTime.ViewModels;
using CoffeeTime.Views;

namespace CoffeeTime
{
    public class App : Application
    {
        private static IServiceProvider Services { get; }

        static App()
        {
            Services = ServiceConfiguration.ConfigureServices();
        }

        public override void Initialize() => AvaloniaXamlLoader.Load(this);

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
}