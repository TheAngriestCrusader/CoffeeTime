using System;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace CoffeeTime.Utilities;

public class Converter
{
    public static Bitmap AvaresToBitmap(string avares)
    {
        return new Bitmap(AssetLoader.Open(new Uri(avares)));
    }
}