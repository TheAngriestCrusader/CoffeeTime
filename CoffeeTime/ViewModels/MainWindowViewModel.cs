using System.Collections.ObjectModel;
using CoffeeTime.Modules.EndpointInfo.ViewModels;
using CoffeeTime.Services;
using CoffeeTime.States;
using CoffeeTime.Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CoffeeTime.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        // States
        [ObservableProperty] private EndpointInfoState _endpointInfo;
        [ObservableProperty] private HeaderState _header;
        [ObservableProperty] private MainDisplayState _mainDisplay;
        
        // Properties
        [ObservableProperty] private bool _isPaneOpen;
        [ObservableProperty] private double _paneMinimizedWidth;
        [ObservableProperty] private string? _togglePaneContent;
        [ObservableProperty] private ObservableCollection<IModuleButtonViewModel> _moduleButtons = [];

        public MainWindowViewModel(
            EndpointInfoState endpointInfo,
            HeaderState header,
            MainDisplayState mainDisplay,
            INavigationService navigation)
        {
            // State assignments
            EndpointInfo = endpointInfo;
            Header = header;
            MainDisplay = mainDisplay;
            
            // Property assignments
            Header.Text = "CoffeeTime";
            IsPaneOpen = true;
            MainDisplay.CurrentControl = new SplashScreenViewModel();
            PaneMinimizedWidth = 48;
            
            // ModuleButtons
            ModuleButtons.Add(
                new ModuleButtonViewModel<EndpointInfoViewModel>(
                    "Endpoint Info",
                    Converter.AvaresToBitmap("avares://CoffeeTime/Assets/EndpointInfoIcon.png"),
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

            foreach (var moduleButton in ModuleButtons)
            {
                moduleButton.IsExpanded = IsPaneOpen;
            }
        }
    }
}
