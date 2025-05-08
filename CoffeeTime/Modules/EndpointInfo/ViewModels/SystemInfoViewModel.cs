using System.Collections.ObjectModel;
using System.ComponentModel;
using CoffeeTime.Modules.EndpointInfo.Models;
using CoffeeTime.Services;
using CoffeeTime.States;
using CoffeeTime.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.Modules.EndpointInfo.ViewModels;

public partial class SystemInfoViewModel : ViewModelBase
{
    // States
    [ObservableProperty] private SystemState _system;

    // Properties
    [ObservableProperty] private string? _title;
    public ObservableCollection<SystemProperty> SystemProperties { get; set; }

    public SystemInfoViewModel(SystemState system, ISystemPollingService systemPollingService)
    {
        // Property assignment
        System = system;

        // Poll system metrics
        systemPollingService.RefreshAsync();

        SystemProperties = [
            new SystemProperty("OsVersion", System.OsVersion),
            new SystemProperty("Is64BitOs", System.Is64BitOs == true ? "Yes" : "No"),
            new SystemProperty("ProcessorCount", System.ProcessorCount.ToString()),
            new SystemProperty("UserDomainName", System.UserDomainName),
            new SystemProperty("UserName", System.UserName)
        ];
    }
}