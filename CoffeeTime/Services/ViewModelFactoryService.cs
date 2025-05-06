using System;
using CoffeeTime.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeTime.Services;

public class ViewModelFactoryService(IServiceProvider serviceProvider) : IViewModelFactoryService
{
    public TVm Create<TVm>() where TVm : ViewModelBase
        => serviceProvider.GetRequiredService<TVm>();
}