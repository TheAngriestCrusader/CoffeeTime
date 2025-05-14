using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoffeeTime.Modules.SystemInfo.Models;
using CoffeeTime.States;

namespace CoffeeTime.Services;

public class SystemPollingService(SystemState system) : ISystemPollingService
{
    public async Task RefreshAsync()
    {
        system.RefreshHardwareInfo();
        system.Hostname = Environment.MachineName;
        system.UserDomainName = Environment.UserDomainName;
        system.UserName = Environment.UserName;

        var drives = await Task.Run(DriveInfo.GetDrives);
        if (!(drives.Length > 0))
        {
            Debug.WriteLine("No drives found.");
        }

        system.Drives.Clear();

        foreach (var drive in drives.Where(driveInfo => driveInfo.IsReady))
        {
            system.Drives.Add(new DriveInfoModel
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