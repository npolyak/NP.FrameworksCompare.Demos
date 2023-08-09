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

        ThePanel.Measure(size);
        //this.Arrange(new Rect(new Size(Bounds.Width, Bounds.Height)));   
        ThePanel.Arrange(new Rect(size));

        renderTargetBitmap.Render(ThePanel);

        //renderTargetBitmap.Save("MyFile.png");

        //ImageBrush imageBrush = new ImageBrush(renderTargetBitmap);
        //TheImage.Background = imageBrush;

        WriteableBitmap writeableBitmap = new WriteableBitmap(pixSize, dpi);
        var buff = writeableBitmap.Lock();

        //Bitmap bitmap = renderTargetBitmap.CreateScaledBitmap(pixSize, BitmapInterpolationMode.HighQuality);
        renderTargetBitmap.CopyPixels
        (
            new PixelRect(new PixelPoint(0, 0), pixSize), 
            buff.Address, 
            sizeof(int) * buff.Size.Width * buff.Size.Height, 
            buff.RowBytes);

        //writeableBitmap.Save("MyFile1.png");

        Bitmap b = new Bitmap(PixelFormats.Bgra8888, AlphaFormat.Unpremul, buff.Address, pixSize, dpi, buff.RowBytes);

        //b.Save("MyFile2.png");

        TheImage.Stretch = Stretch.None;
        TheImage.Source = b;
    }

    private void MainView_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {



    }
}
