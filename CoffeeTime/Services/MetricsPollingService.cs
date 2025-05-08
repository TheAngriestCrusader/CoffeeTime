using System;
using System.Threading.Tasks;
using CoffeeTime.States;

namespace CoffeeTime.Services;

public class MetricsPollingService(SystemState system) : IMetricsPollingService
{
    public async Task RefreshAsync()
    {
        system.Hostname = Environment.MachineName;
        system.OsVersion = Environment.OSVersion.ToString();
        system.ProcessorCount = Environment.ProcessorCount;
        system.UserDomainName = Environment.UserDomainName;
        system.UserName = Environment.UserName;
        system.Is64BitOs = Environment.Is64BitOperatingSystem;
    }
}