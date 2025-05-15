using System.Collections.ObjectModel;
using CoffeeTime.States;
using CoffeeTime.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CoffeeTime.Modules.PathWatchers.ViewModels;

public partial class PathWatchersViewModel : ViewModelBase
{
    [ObservableProperty] private string _newPath = string.Empty;
    [ObservableProperty] private ObservableCollection<string> _pathWatchers = [];
    
    public PathWatchersViewModel(HeaderState header)
    {
        header.Text = "Path Watcher";
    }

    [RelayCommand]
    public void AddPathWatcher()
    {
        NewPath = string.Empty;
    }

    [RelayCommand]
    public void ConfigurePathWatcher()
    {
        
    }
}