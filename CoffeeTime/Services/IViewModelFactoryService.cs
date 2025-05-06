using CoffeeTime.ViewModels;

namespace CoffeeTime.Services;

public interface IViewModelFactoryService
{
    TVm Create<TVm>() where TVm : ViewModelBase;
}