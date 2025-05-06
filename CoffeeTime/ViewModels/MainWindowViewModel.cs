using System.Collections.ObjectModel;
using CoffeeTime.Modules.EndpointInfo.ViewModels;
using CoffeeTime.Services;
using CoffeeTime.States;
using CoffeeTime.Utilities;
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
    [ObservableProperty] private string? _togglePaneContent;

    public MainWindowViewModel(
        HeaderState header,
        MainDisplayState mainDisplay,
        IModuleNavigationService moduleNavigation)
    {
        // State assignments
        Header = header;
        MainDisplay = mainDisplay;

        // Property assignments
        Header.Text = "CoffeeTime";
        IsPaneOpen = true;
        PaneMinimizedWidth = 48;

        // ModuleButtons
        ModuleButtons.Add(
            new ModuleButtonViewModel<EndpointInfoViewModel>(
                "Endpoint Info",
                Converter.AvaresToBitmap("avares://CoffeeTime/Assets/EndpointInfoIcon.png"),
                moduleNavigation));
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