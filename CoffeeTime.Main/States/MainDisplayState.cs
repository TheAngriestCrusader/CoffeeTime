using CoffeeTime.Main.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.Main.States;

public partial class MainDisplayState : ObservableObject
{
    [ObservableProperty] private ViewModelBase? _currentControl;
}