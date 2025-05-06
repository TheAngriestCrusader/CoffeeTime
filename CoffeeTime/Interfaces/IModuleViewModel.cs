namespace CoffeeTime.Interfaces;

public interface IModuleViewModel
{
    string? RequiredOsName { get; }
    bool Requires64Bit { get; }
}