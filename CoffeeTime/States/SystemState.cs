using System.Collections.ObjectModel;
using CoffeeTime.Modules.EndpointInfo.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.States;

public partial class SystemState : ObservableObject
{
    
    [ObservableProperty] private string _hostname = string.Empty;
    [ObservableProperty] private string _osVersion = string.Empty;
    [ObservableProperty] private int _processorCount;
    [ObservableProperty] private string _userDomainName = string.Empty;
    [ObservableProperty] private string _userName = string.Empty;
    [ObservableProperty] private bool _is64BitOs;
    public ObservableCollection<DriveInfoModel> Drives { get; } = [];
}