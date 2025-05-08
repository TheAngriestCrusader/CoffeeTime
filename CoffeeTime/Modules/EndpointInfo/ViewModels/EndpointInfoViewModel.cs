using System.Collections.ObjectModel;
using System.ComponentModel;
using CoffeeTime.Modules.EndpointInfo.Models;
using CoffeeTime.Services;
using CoffeeTime.States;
using CoffeeTime.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.Modules.EndpointInfo.ViewModels;

public partial class EndpointInfoViewModel : ViewModelBase
{
    // Module properties
    public static string? RequiredOsName { get; } = null;
    public static bool Requires64Bit { get; } = false;
    public static bool RequiresAdministrator { get; } = false;
    
    // States
    [ObservableProperty] private SystemState _system;

    // Properties
    [ObservableProperty] private string? _title;
    public ObservableCollection<SystemProperty> SystemProperties { get; set; }

    public EndpointInfoViewModel(SystemState system, IMetricsPollingService metricsPollingService)
    {
        // Property assignment
        System = system;

        // Poll system metrics
        metricsPollingService.RefreshAsync();

        SystemProperties = [
            new SystemProperty("OsVersion", System.OsVersion),
            new SystemProperty("Is64BitOs", System.Is64BitOs == true ? "Yes" : "No"),
            new SystemProperty("ProcessorCount", System.ProcessorCount.ToString()),
            new SystemProperty("UserDomainName", System.UserDomainName),
            new SystemProperty("UserName", System.UserName)
        ];
    }
}