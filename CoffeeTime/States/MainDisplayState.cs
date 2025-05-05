using CoffeeTime.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.States;

public partial class MainDisplayState : ObservableObject
{
    [ObservableProperty] private ViewModelBase? _currentControl;
}