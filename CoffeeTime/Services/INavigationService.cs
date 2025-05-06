using CoffeeTime.ViewModels;

namespace CoffeeTime.Services;

public interface INavigationService
{
    void Navigate<T>() where T : ViewModelBase;
}