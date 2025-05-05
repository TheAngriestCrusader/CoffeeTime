using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CoffeeTime.Main.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _headerText;

        [ObservableProperty] private bool _isPaneOpen;

        public MainWindowViewModel()
        {
            HeaderText = "This is header text.";
            IsPaneOpen = true;
        }

        [RelayCommand]
        private void TogglePane()
        {
            IsPaneOpen = !IsPaneOpen;
        }
    }
}
