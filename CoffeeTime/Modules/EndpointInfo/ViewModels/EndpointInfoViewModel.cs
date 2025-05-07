using System.ComponentModel;
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
    [ObservableProperty] private EndpointState _endpoint;

    // Properties
    [ObservableProperty] private string? _title;

    public EndpointInfoViewModel(EndpointState endpoint, IMetricsPollingService metricsPollingService)
    {
        // Property assignment
        Endpoint = endpoint;

        // Poll system metrics
        metricsPollingService.RefreshAsync();
    }
}