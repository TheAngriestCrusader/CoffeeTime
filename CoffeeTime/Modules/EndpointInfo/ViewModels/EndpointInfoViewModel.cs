using System.ComponentModel;
using CoffeeTime.Interfaces;
using CoffeeTime.Services;
using CoffeeTime.States;
using CoffeeTime.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.Modules.EndpointInfo.ViewModels;

public partial class EndpointInfoViewModel : ViewModelBase, IModuleViewModel
{
    // States
    [ObservableProperty] private EndpointState _endpoint;

    // Properties
    [ObservableProperty] private string? _osVersion;
    [ObservableProperty] private string? _title;

    public EndpointInfoViewModel(EndpointState endpoint, IMetricsPollingService metricsPollingService)
    {
        // Module properties
        RequiredOsName = null;
        Requires64Bit = false;
        RequiresAdministrator = false;

        // Property assignment
        Endpoint = endpoint;
        Endpoint.PropertyChanged += OnEndpointPropertyChanged;
        UpdateTitle();

        // Poll system metrics
        metricsPollingService.RefreshAsync();
    }

    // Module properties
    public string? RequiredOsName { get; }
    public bool Requires64Bit { get; }
    public bool RequiresAdministrator { get; }

    private void OnEndpointPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(Endpoint.OsVersion):
                UpdateOsVersion();

                break;

            case nameof(Endpoint.Hostname):
                UpdateTitle();

                break;
        }
    }

    private void UpdateOsVersion()
    {
        OsVersion = $"OsVersion: {Endpoint.OsVersion}";
    }

    private void UpdateTitle()
    {
        Title = $"System info for {Endpoint.Hostname}";
    }
}