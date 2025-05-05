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
        [ObservableProperty] private bool _isPaneHeaderVisible;
        [ObservableProperty] private double _paneMinimizedWidth;
        [ObservableProperty] private string _togglePaneContent;

        public MainWindowViewModel(HeaderState header, MainDisplayState mainDisplay)
        {
            // State assignments
            Header = header;
            MainDisplay = mainDisplay;
            
            // Property assignments
            Header.Text = "Coffee Time";
            IsPaneOpen = true;
            IsPaneHeaderVisible = IsPaneOpen ? true : false;
            MainDisplay.CurrentControl = new SplashScreenViewModel();
            PaneMinimizedWidth = 32;
            TogglePaneContent = IsPaneOpen ? "<" : ">";
        }

        [RelayCommand]
        private void TogglePane()
        {
            IsPaneOpen = !IsPaneOpen;
            IsPaneHeaderVisible = IsPaneOpen ? true : false;
            TogglePaneContent = IsPaneOpen ? "<" : ">";
        }
    }
}
