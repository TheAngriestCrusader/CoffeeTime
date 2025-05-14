using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CoffeeTime.Modules.SystemInfo.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Hardware.Info;

namespace CoffeeTime.States;

public partial class SystemState : ObservableObject
{
    [ObservableProperty] private string _hostname = string.Empty;
    [ObservableProperty] private string _userDomainName = string.Empty;
    [ObservableProperty] private string _userName = string.Empty;
    public ObservableCollection<DriveInfoModel> Drives { get; } = [];
    public HardwareInfo HardwareInfo { get; } = new();
    [ObservableProperty] private bool _hardwareInfoIsLoading;
    public Action? HardwareInfoIsLoaded;

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