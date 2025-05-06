using CoffeeTime.Interfaces;
using CoffeeTime.States;
using CoffeeTime.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.Modules.EndpointInfo.ViewModels;

public partial class EndpointInfoViewModel : ViewModelBase, IModuleViewModel
{
    // Module properties
    public string? RequiredOsName { get; }
    public bool Requires64Bit { get; }
    
    // States
    [ObservableProperty] private EndpointState _endpoint;
    
    // Properties
    [ObservableProperty] private string _placeholder = "This is Endpoint";

    public EndpointInfoViewModel(EndpointState endpoint)
    {
        // Module properties
        RequiredOsName = null;
        Requires64Bit = false;
        
        // Property assignment
        Endpoint = endpoint;
    }
}