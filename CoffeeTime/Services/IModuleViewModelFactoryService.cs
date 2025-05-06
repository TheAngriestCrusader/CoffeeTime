using CoffeeTime.Interfaces;

namespace CoffeeTime.Services;

public interface IModuleViewModelFactoryService
{
    TVm Create<TVm>() where TVm : IModuleViewModel;
}