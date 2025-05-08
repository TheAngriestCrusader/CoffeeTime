using System.Collections.ObjectModel;
using CoffeeTime.Modules.EndpointInfo.ViewModels;
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
    [ObservableProperty] private ObservableCollection<IModuleButtonViewModel> _moduleButtons = [];
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
        IsPaneOpen = false;
        PaneMinimizedWidth = 48;
        PaneMaximizedWidth = PaneMinimizedWidth * 5;

        // ModuleButtons
        ModuleButtons.Add(
            new ModuleButtonViewModel<EndpointInfoViewModel>(
                "Endpoint Info",
                "avares://CoffeeTime/Assets/EndpointInfoIcon.png",
                navigation));
        UpdatePaneWidgets();
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