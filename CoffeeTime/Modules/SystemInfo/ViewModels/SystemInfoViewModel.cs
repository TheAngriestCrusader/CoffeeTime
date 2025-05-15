using System.Collections.Generic;
using System.Collections.ObjectModel;
using CoffeeTime.Services;
using CoffeeTime.States;
using CoffeeTime.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.Modules.SystemInfo.ViewModels;

public partial class SystemInfoViewModel : ViewModelBase
{
    // States
    [ObservableProperty] private SystemState _system;

    // Properties
    [ObservableProperty] private string? _title;
    [ObservableProperty] private ObservableCollection<KeyValuePair<string, string>> _systemProperties = [];

    public SystemInfoViewModel(SystemState system, HeaderState header, ISystemPollingService systemPollingService)
    {
        header.Text = "System Info";
        
        // Property assignment
        System = system;

        // Poll system metrics
        systemPollingService.RefreshAsync();
        UpdateSystemProperties();
        System.HardwareInfoIsLoaded += UpdateSystemProperties;
    }

    private void UpdateSystemProperties()
    {
        SystemProperties =
        [
            new("Username", $"{System.UserDomainName}\\{System.UserName}"),
            new("OS Name", System.HardwareInfo.OperatingSystem.Name),
            new("OS Version", System.HardwareInfo.OperatingSystem.VersionString)
        ];
    }
}