using CoffeeTime.Main.States;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CoffeeTime.Main.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private HeaderState _header;

        [ObservableProperty]
        private bool _isPaneOpen;

        public MainWindowViewModel(HeaderState header)
        {
            Header = header;
            Header.Text = "Coffee Time";
            IsPaneOpen = true;
        }

        [RelayCommand]
        private void TogglePane()
        {
            IsPaneOpen = !IsPaneOpen;
        }
    }
}
