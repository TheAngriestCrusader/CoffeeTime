using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.States;

public partial class HeaderState : ObservableObject
{
    [ObservableProperty] private string? _text;
}