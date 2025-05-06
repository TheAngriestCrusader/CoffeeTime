using CoffeeTime.Interfaces;

namespace CoffeeTime.Services;

public interface IModuleNavigationService
{
    void Navigate<T>() where T : IModuleViewModel;
}