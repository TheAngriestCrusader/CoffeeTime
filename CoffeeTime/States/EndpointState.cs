using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.States;

public partial class EndpointState : ObservableObject
{
    [ObservableProperty] private string? _hostname;
    [ObservableProperty] private string? _osName;
}