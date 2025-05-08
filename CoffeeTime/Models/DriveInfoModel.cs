namespace CoffeeTime.Models;

public class DriveInfoModel
{
    public required string Name { get; set; }
    public required string DriveFormat { get; set; }
    public required string DriveType { get; set; }
    public string VolumeLabel { get; set; } = "Not Ready";
}