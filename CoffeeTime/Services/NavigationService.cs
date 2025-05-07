using CoffeeTime.States;
using CoffeeTime.ViewModels;

namespace CoffeeTime.Services;

public class NavigationService(IViewModelFactoryService factory, MainDisplayState display) : INavigationService
{
    public void Navigate<TVm>() where TVm : ViewModelBase
    {
        display.CurrentControl = factory.Create<TVm>();
    }
}