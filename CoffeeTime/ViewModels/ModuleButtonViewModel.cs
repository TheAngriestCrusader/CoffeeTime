using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Media.Imaging;
using CoffeeTime.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CoffeeTime.ViewModels
{
    public partial class ModuleButtonViewModel<TModuleVm> : ViewModelBase, IModuleButtonViewModel
        where TModuleVm : ViewModelBase
    {
        [ObservableProperty] private Bitmap _icon;
        [ObservableProperty] private bool _isTitleVisible;
        [ObservableProperty] private string _title;

        public ObservableCollection<Bitmap> DependencyIcons { get; } = [];
        public INavigationService Navigation { get; }
        public ICommand OpenModule { get; }
        

        public ModuleButtonViewModel(
            string title,
            Bitmap icon,
            INavigationService navigation)
        {
            Icon  = icon;
            Navigation = navigation;
            OpenModule = new RelayCommand(() => Navigation.Navigate<TModuleVm>());
            Title = title;
        }
    }
}