using System.Threading.Tasks;

namespace CoffeeTime.Services;

public interface ISystemPollingService
{
    Task RefreshAsync();
}