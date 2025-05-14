namespace CoffeeTime.Modules.EndpointInfo.Models;

public class DriveInfoModel
{
    public required string Name { get; set; }
    public required string VolumeLabel { get; set; }
    public required string DriveType { get; init; }
    public required string DriveFormat { get; init; }
    public required long TotalSize { get; set; }
    public required long TotalFreeSpace { get; init; }
    public double TotalUsedSpace => TotalSize - TotalFreeSpace;
}