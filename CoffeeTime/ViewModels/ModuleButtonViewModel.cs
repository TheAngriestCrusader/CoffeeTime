using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Media.Imaging;
using CoffeeTime.Interfaces;
using CoffeeTime.Services;
using CoffeeTime.States;
using CoffeeTime.Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CoffeeTime.ViewModels;

public partial class ModuleButtonViewModel<TModuleVm> : ViewModelBase, IModuleButtonViewModel
    where TModuleVm : ViewModelBase, IModuleViewModel
{
    private static Bitmap _linuxDependencyIcon =
        Converter.AvaresToBitmap("avares://CoffeeTime/Assets/LinuxModuleIcon.png");

    private static Bitmap _windowsDependencyIcon =
        Converter.AvaresToBitmap("avares://CoffeeTime/Assets/WindowsModuleIcon.png");

    [ObservableProperty] private Bitmap _icon;
    [ObservableProperty] private bool _isExpanded;
    [ObservableProperty] private string _title;

    public ModuleButtonViewModel(
        string title,
        Bitmap icon,
        IModuleNavigationService moduleNavigation)
    {
        Icon = icon;
        OpenModule = new RelayCommand(moduleNavigation.Navigate<TModuleVm>);
        Title = title;
    }

    public ObservableCollection<Bitmap> DependencyIcons { get; } = [];
    public ICommand OpenModule { get; }
}