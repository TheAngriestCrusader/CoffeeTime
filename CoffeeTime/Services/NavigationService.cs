using CoffeeTime.States;
using CoffeeTime.ViewModels;

namespace CoffeeTime.Services;

public class NavigationService(IViewModelFactoryService factory, MainDisplayState display) : INavigationService
{
    
    public void Navigate<T>() where T : ViewModelBase
    {
        display.CurrentControl = factory.Create<T>();
    }
}