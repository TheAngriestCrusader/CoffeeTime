using System;
using System.Collections.ObjectModel;
using Avalonia.Media.Imaging;
using CoffeeTime.States;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CoffeeTime.ViewModels;

public partial class ModuleButtonViewModel : ViewModelBase
{
    [ObservableProperty] private MainDisplayState _mainDisplay;
    
    [ObservableProperty] private ObservableCollection<Bitmap> _dependencyIcons = [];
    [ObservableProperty] private bool _isTitleVisible;
    [ObservableProperty] private string _title;

    private readonly Func<ViewModelBase> _factory;

    public ModuleButtonViewModel(string title, Func<ViewModelBase> factory, MainDisplayState mainDisplay)
    {
        Title = title;
        _factory = factory;
        MainDisplay = mainDisplay;
    }

    [RelayCommand]
    public void OpenModule()
    {
        MainDisplay.CurrentControl = _factory();
    }
}