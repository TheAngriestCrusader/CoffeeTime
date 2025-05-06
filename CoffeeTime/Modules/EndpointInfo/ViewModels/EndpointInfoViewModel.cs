using CoffeeTime.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.Modules.EndpointInfo.ViewModels;

public partial class EndpointInfoViewModel : ViewModelBase
{
    [ObservableProperty] private string _placeholder = "This is EndpointInfo";
}