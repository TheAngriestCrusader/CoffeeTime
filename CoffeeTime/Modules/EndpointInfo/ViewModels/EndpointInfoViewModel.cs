using CoffeeTime.States;
using CoffeeTime.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.Modules.EndpointInfo.ViewModels;

public partial class EndpointInfoViewModel : ViewModelBase
{
    // States
    [ObservableProperty] private EndpointInfoState _endpointInfo;
    
    // Properties
    [ObservableProperty] private string _placeholder = "This is EndpointInfo";

    public EndpointInfoViewModel(EndpointInfoState endpointInfo)
    {
        EndpointInfo = endpointInfo;
    }
}