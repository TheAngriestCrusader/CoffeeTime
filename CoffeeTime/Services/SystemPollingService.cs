using System;
using System.IO;
using System.Threading.Tasks;
using CoffeeTime.Models;
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

        var drives = await Task.Run(() => DriveInfo.GetDrives());
        foreach (var drive in drives)
        {
            var model = new DriveInfoModel
            {
                Name = drive.Name,
                DriveFormat = drive.DriveFormat,
                DriveType = drive.DriveType.ToString()
            };

            if (drive.IsReady)
            {
                model.VolumeLabel = drive.VolumeLabel;
            }
            
            system.Drives.Add(model);
        }
    }
}