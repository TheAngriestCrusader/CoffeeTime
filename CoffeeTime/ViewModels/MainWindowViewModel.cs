using System.Collections.ObjectModel;
using CoffeeTime.Modules.EndpointInfo.ViewModels;
using CoffeeTime.States;
using CoffeeTime.Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CoffeeTime.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        // States
        [ObservableProperty] private HeaderState _header;
        [ObservableProperty] private MainDisplayState _mainDisplay;
        
        // Properties
        [ObservableProperty] private bool _isPaneOpen;
        [ObservableProperty] private double _paneMinimizedWidth;
        [ObservableProperty] private string? _togglePaneContent;
        [ObservableProperty] private ObservableCollection<ModuleButtonViewModel> _moduleButtons = [];

        public MainWindowViewModel(HeaderState header, MainDisplayState mainDisplay)
        {
            // State assignments
            Header = header;
            MainDisplay = mainDisplay;
            
            // Property assignments
            Header.Text = "Coffee Time";
            IsPaneOpen = true;
            MainDisplay.CurrentControl = new SplashScreenViewModel();
            PaneMinimizedWidth = 48;
            
            // ModuleButtons
            ModuleButtons.Add(new ModuleButtonViewModel(
                "Path Watcher",
                () => new EndpointInfoViewModel(),
                Converter.AvaresToBitmap("avares://CoffeeTime/Assets/EndpointInfoIcon.png"),
                MainDisplay));
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
                moduleButton.IsTitleVisible = IsPaneOpen;
            }
        }
    }
}
