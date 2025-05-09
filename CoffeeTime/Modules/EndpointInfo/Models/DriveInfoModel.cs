namespace CoffeeTime.Modules.EndpointInfo.Models;

public class DriveInfoModel
{
    public required string Name { get; set; }
    public required string VolumeLabel { get; set; }
    public required string DriveType { get; set; }
    public required string DriveFormat { get; set; }
    public required long TotalSize { get; set; }
    public required long TotalFreeSpace { get; set; }
    public double TotalUsedSpace => TotalSize - TotalFreeSpace;
    public int TotalUsedSpacePercent => (int)(TotalUsedSpace / TotalSize * 100);
}