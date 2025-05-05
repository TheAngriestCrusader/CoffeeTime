using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.Main.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string headerText;

        public MainWindowViewModel()
        {
            HeaderText = "This is header text.";
        }
    }
}
