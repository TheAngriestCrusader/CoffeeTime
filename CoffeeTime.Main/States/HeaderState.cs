using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.Main.States;

public partial class HeaderState : ObservableObject
{
    [ObservableProperty]
    private string? _text;
}