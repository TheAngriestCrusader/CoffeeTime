using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Media.Imaging;

namespace CoffeeTime.ViewModels;

public interface IModuleButtonViewModel
{
    ObservableCollection<Bitmap>? DependencyIcons { get; }
    Bitmap Icon { get; }
    bool IsExpanded { get; set; }
    ICommand OpenModule { get; }
    string Title { get; }
}