using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CoffeeTime.Modules.SystemInfo.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Hardware.Info;

namespace CoffeeTime.States;

public partial class SystemState : ObservableObject
{
    // Basic Info
    [ObservableProperty] private string _hostname = string.Empty;
    [ObservableProperty] private string _userDomainName = string.Empty;
    [ObservableProperty] private string _userName = string.Empty;
    [ObservableProperty] private ObservableCollection<DriveInfoModel> _drives = [];
    
    // Hardware.Info
    public readonly HardwareInfo HardwareInfo = new();
    [ObservableProperty] private bool _hardwareInfoIsLoading;
    public Action? HardwareInfoIsLoaded;
    
    // Advanced Info
    [ObservableProperty] private ObservableCollection<NetworkAdapter> _networkAdapters = [];

    public async void RefreshHardwareInfo()
    {
        HardwareInfoIsLoading = true;

        await Task.Run(() =>
        {
            HardwareInfo.RefreshAll();
        });

        HardwareInfoIsLoading = false;
        HardwareInfoIsLoaded?.Invoke();
    }
}