using System.Threading.Tasks;

namespace CoffeeTime.Services;

public interface IMetricsPollingService
{
    Task RefreshAsync();
}