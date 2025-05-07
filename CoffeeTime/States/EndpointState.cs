using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.States;

public partial class EndpointState : ObservableObject
{
    [ObservableProperty] private string? _hostname;
    [ObservableProperty] private string? _osVersion;
    [ObservableProperty] private int? _processorCount;
    [ObservableProperty] private string? _userDomainName;
    [ObservableProperty] private string? _userName;
    [ObservableProperty] private bool? _is64BitOs;
}