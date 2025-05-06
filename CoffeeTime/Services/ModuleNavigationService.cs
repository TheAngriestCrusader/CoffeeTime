using CoffeeTime.Interfaces;
using CoffeeTime.States;

namespace CoffeeTime.Services;

public class ModuleNavigationService(IModuleViewModelFactoryService factory, MainDisplayState display) : IModuleNavigationService
{
    public void Navigate<T>() where T : IModuleViewModel
    {
        display.CurrentControl = factory.Create<T>();
    }
}