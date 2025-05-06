using System;
using System.Threading.Tasks;
using CoffeeTime.States;

namespace CoffeeTime.Services;

public class MetricsPollingService(EndpointState endpoint) : IMetricsPollingService
{
    public async Task RefreshAsync()
    {
        endpoint.Hostname = Environment.MachineName;
        endpoint.OsVersion = Environment.OSVersion.ToString();
    }
}