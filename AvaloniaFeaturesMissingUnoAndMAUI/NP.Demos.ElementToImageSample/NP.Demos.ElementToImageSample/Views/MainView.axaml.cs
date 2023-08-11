using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System.Runtime.InteropServices;

namespace NP.Demos.ElementToImageSample.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        RenderButton.Click += RenderButton_Click;
    }

    private void RenderButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        PixelSize pixSize = new PixelSize((int)ThePanel.Bounds.Width, (int)ThePanel.Bounds.Height);
        var dpi = new Avalonia.Vector(96d, 96d);

        using RenderTargetBitmap renderTargetBitmap = 
            new RenderTargetBitmap(pixSize, dpi);
        var size = new Size(ThePanel.Bounds.Width, ThePanel.Bounds.Height);

        renderTargetBitmap.Render(ThePanel);

        WriteableBitmap writeableBitmap = new WriteableBitmap(pixSize, dpi);
        var buff = writeableBitmap.Lock();

        renderTargetBitmap.CopyPixels
        (
            new PixelRect(new PixelPoint(0, 0), pixSize), 
            buff.Address, 
            sizeof(int) * buff.Size.Width * buff.Size.Height, 
            buff.RowBytes);

        Bitmap b = 
            new Bitmap
            (
                renderTargetBitmap.Format.Value, 
                AlphaFormat.Premul, 
                buff.Address, 
                pixSize, 
                dpi, 
                buff.RowBytes);

        TheImage.Stretch = Stretch.None;
        TheImage.Source = b;
    }
}
