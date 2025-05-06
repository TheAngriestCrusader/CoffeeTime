using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Media.Imaging;
using CoffeeTime.Services;
using CoffeeTime.Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CoffeeTime.ViewModels
{
    public partial class ModuleButtonViewModel<TModuleVm> : ViewModelBase, IModuleButtonViewModel
        where TModuleVm : ViewModelBase
    {
        [ObservableProperty] private Bitmap _icon;
        [ObservableProperty] private bool _isExpanded;
        [ObservableProperty] private string _title;

        public ObservableCollection<Bitmap> DependencyIcons { get; } = [];
        public ICommand OpenModule { get; }
        
        public ModuleButtonViewModel(
            string title,
            Bitmap icon,
            INavigationService navigation)
        {
            Icon = icon;
            OpenModule = new RelayCommand(navigation.Navigate<TModuleVm>);
            Title = title;

            var img = Converter.AvaresToBitmap("avares://CoffeeTime/Assets/WindowsModuleIcon.png");
            DependencyIcons.Add(img);
        }
    }
}