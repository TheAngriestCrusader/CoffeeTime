namespace CoffeeTime.Modules.EndpointInfo.Models;

public class SystemProperty(string name, string? value)
{
    public string Name { get; init; } = name;
    public string? Value { get; init; } = value;
}