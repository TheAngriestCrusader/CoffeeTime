using System.Collections.ObjectModel;
using CoffeeTime.States;
using CoffeeTime.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CoffeeTime.Modules.PathWatcher.ViewModels;

public partial class PathWatcherViewModel : ViewModelBase
{
    [ObservableProperty] private ObservableCollection<string> _pathWatchers = [];
    
    public PathWatcherViewModel(HeaderState header)
    {
        header.Text = "Path Watcher";
    }

    [RelayCommand]
    public void ConfigurePathWatcher()
    {
        
    }
}