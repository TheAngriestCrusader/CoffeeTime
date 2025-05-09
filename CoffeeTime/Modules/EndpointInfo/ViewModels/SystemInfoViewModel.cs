using System.Collections.Generic;
using System.Collections.ObjectModel;
using CoffeeTime.Modules.EndpointInfo.Models;
using CoffeeTime.Services;
using CoffeeTime.States;
using CoffeeTime.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeTime.Modules.EndpointInfo.ViewModels;

public partial class SystemInfoViewModel : ViewModelBase
{
    // States
    [ObservableProperty] private SystemState _system;

    // Properties
    [ObservableProperty] private string? _title;
    public ObservableCollection<KeyValuePair<string, string>> SystemProperties { get; set; }
    public ObservableCollection<DriveInfoModel> Drives { get; set; }

    public SystemInfoViewModel(SystemState system, ISystemPollingService systemPollingService)
    {
        // Property assignment
        System = system;

        // Poll system metrics
        systemPollingService.RefreshAsync();

        SystemProperties = [
            new ("OsVersion", System.OsVersion),
            new ("Is64BitOs", System.Is64BitOs == true ? "Yes" : "No"),
            new ("ProcessorCount", System.ProcessorCount.ToString()),
            new ("UserDomainName", System.UserDomainName),
            new ("UserName", System.UserName)
        ];

        Drives = [];
        foreach (var drive in system.Drives)
        {
            Drives.Add(new DriveInfoModel
            {
                Name = drive.Name,
                VolumeLabel = drive.VolumeLabel,
                DriveType = drive.DriveType.ToString(),
                DriveFormat = drive.DriveFormat,
                TotalSize = drive.TotalSize,
                TotalFreeSpace = drive.TotalFreeSpace
            });
        }
    }
}