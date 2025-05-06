using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Media.Imaging;
using CoffeeTime.Services;

namespace CoffeeTime.ViewModels;

public interface IModuleButtonViewModel
{
    ObservableCollection<Bitmap> DependencyIcons { get; }
    bool IsTitleVisible { get; set;  }
    Bitmap Icon { get; }
    ICommand OpenModule { get; }
    INavigationService Navigation { get; }
    string Title { get; }
}