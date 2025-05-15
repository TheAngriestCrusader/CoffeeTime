using CoffeeTime.ViewModels;

namespace CoffeeTime.Services;

public interface INavigationService
{
    void Navigate<TVm>() where TVm : ViewModelBase;
}