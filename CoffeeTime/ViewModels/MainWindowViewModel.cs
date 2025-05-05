using System.Collections.ObjectModel;
using CoffeeTime.States;
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
            PaneMinimizedWidth = 32;
            
            // ModuleButtons
            ModuleButtons.Add(new ModuleButtonViewModel("Test", () => new ViewModelBase(), MainDisplay));
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
