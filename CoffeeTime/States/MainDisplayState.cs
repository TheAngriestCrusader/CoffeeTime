using CoffeeTime.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.States;

public partial class MainDisplayState : ObservableObject
{
    [ObservableProperty] private IModuleViewModel? _currentControl;
}