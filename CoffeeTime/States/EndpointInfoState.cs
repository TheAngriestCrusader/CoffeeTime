using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.States;

public partial class EndpointInfoState : ObservableObject
{
    [ObservableProperty] private string? _hostname;
    [ObservableProperty] private string? _osName;
}