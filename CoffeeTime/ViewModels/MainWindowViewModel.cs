﻿using System.Collections.ObjectModel;
using CoffeeTime.Modules.PathWatchers.ViewModels;
using CoffeeTime.Modules.SystemInfo.ViewModels;
using CoffeeTime.Services;
using CoffeeTime.States;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CoffeeTime.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // States
    [ObservableProperty] private HeaderState _header;

    // Properties
    [ObservableProperty] private bool _isPaneOpen;
    [ObservableProperty] private MainDisplayState _mainDisplay;
    [ObservableProperty] private ObservableCollection<IModuleButtonViewModel> _moduleButtons;
    [ObservableProperty] private double _paneMinimizedWidth;
    [ObservableProperty] private double _paneMaximizedWidth;
    [ObservableProperty] private string? _togglePaneContent;

    public MainWindowViewModel(
        HeaderState header,
        MainDisplayState mainDisplay,
        INavigationService navigation)
    {
        // State assignments
        Header = header;
        MainDisplay = mainDisplay;

        // Property assignments
        Header.Text = "CoffeeTime";
        IsPaneOpen = true;
        PaneMinimizedWidth = 36;
        PaneMaximizedWidth = PaneMinimizedWidth * 5;

        // ModuleButtons
        ModuleButtons =
        [
            new ModuleButtonViewModel<PathWatchersViewModel>(
                "Path Watchers",
                "avares://CoffeeTime/Assets/PathWatchersIcon.png",
                navigation),
            new ModuleButtonViewModel<SystemInfoViewModel>(
                "System Info",
                "avares://CoffeeTime/Assets/SystemInfoIcon.png",
                navigation)
        ];
        UpdatePaneWidgets();
        navigation.Navigate<SystemInfoViewModel>();
    }

    [RelayCommand]
    private void TogglePane()
    {
        IsPaneOpen = !IsPaneOpen;
        UpdatePaneWidgets();
    }

    private void UpdatePaneWidgets()
    {
        TogglePaneContent = IsPaneOpen ? "<" : ">";
        foreach (var moduleButton in ModuleButtons) moduleButton.IsExpanded = IsPaneOpen;
    }
}