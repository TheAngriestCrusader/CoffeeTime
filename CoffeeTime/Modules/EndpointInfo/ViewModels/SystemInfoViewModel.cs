using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public ObservableCollection<KeyValuePair<string, string>> SystemProperties { get; set; }

    public SystemInfoViewModel(SystemState system, ISystemPollingService systemPollingService)
    {
        // Property assignment
        System = system;

        // Poll system metrics
        systemPollingService.RefreshAsync();

        SystemProperties = [
            new ("Is64BitOs", System.Is64BitOs ? "Yes" : "No"),
            new ("OsVersion", System.OsVersion),
            new ("ProcessorCount", System.ProcessorCount.ToString()),
            new ("UserDomainName", System.UserDomainName),
            new ("UserName", System.UserName)
        ];
    }
}