using System;
using CoffeeTime.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeTime.Services;

public class ModuleModuleViewModelFactoryService(IServiceProvider serviceProvider) : IModuleViewModelFactoryService
{
    public TVm Create<TVm>() where TVm : IModuleViewModel
    {
        return serviceProvider.GetRequiredService<TVm>();
    }
}