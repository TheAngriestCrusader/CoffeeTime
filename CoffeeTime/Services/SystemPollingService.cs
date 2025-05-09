using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoffeeTime.Modules.EndpointInfo.Models;
using CoffeeTime.States;

namespace CoffeeTime.Services;

public class SystemPollingService(SystemState system) : ISystemPollingService
{
    public async Task RefreshAsync()
    {
        system.Hostname = Environment.MachineName;
        system.OsVersion = Environment.OSVersion.ToString();
        system.ProcessorCount = Environment.ProcessorCount;
        system.UserDomainName = Environment.UserDomainName;
        system.UserName = Environment.UserName;
        system.Is64BitOs = Environment.Is64BitOperatingSystem;

        // Clear and populate the Drives collection with DriveInfoModel
        var drives = await Task.Run(DriveInfo.GetDrives);
        if (!drives.Any())
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